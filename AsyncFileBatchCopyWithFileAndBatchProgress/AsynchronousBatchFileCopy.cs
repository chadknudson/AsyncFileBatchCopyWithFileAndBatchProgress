using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    public partial class AsynchronousBatchFileCopy : Form
    {
        public Dictionary<string, string> sourceFilesToDestinationMap = new Dictionary<string, string>();

        private StatusDialog status = new StatusDialog();

        public AsynchronousBatchFileCopy()
        {
            InitializeComponent();
        }

        private void BrowseForTargetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = TargetFolderTextBox.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                TargetFolderTextBox.Text = folderBrowser.SelectedPath;
                SourceFilesButton.Visible = Directory.Exists(TargetFolderTextBox.Text);
                SourceFilesButton.Enabled = Directory.Exists(TargetFolderTextBox.Text);
            }
        }

        private void SourceFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog sourceFiles = new OpenFileDialog();
            sourceFiles.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sourceFiles.Multiselect = true;
            sourceFiles.Filter = "All Files|*.*";
            if (sourceFiles.ShowDialog() == DialogResult.OK)
            {
                foreach (string sourceFilename in sourceFiles.FileNames)
                {
                    sourceFilesToDestinationMap[sourceFilename] = Path.Combine(TargetFolderTextBox.Text, Path.GetFileName(sourceFilename));
                }
                CopyButton.Visible = true;
                CopyButton.Enabled = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                await CopyFiles();
            }
            catch (OperationCanceledException)
            {
                status.Close();
                MessageBox.Show("User cancelled the operation.", "Long Running Process Cancelled", MessageBoxButtons.OK);
            }
        }

        public async Task CopyFiles()
        {
            status = new StatusDialog();

            status.OverallMaximum = FileIO.GetFileBatchLength(sourceFilesToDestinationMap.Keys.ToArray());

            IProgress<FileBatchProgressData> progress = new SynchronousProgress<FileBatchProgressData>(value =>
            {
                status.CurrentItemCaption = "Copying File # " + (value.BatchFileIndex + 1).ToString() + " of " + value.BatchFileCount.ToString() + " " + value.Filename;

                status.ItemMaximum = value.FileLength;

                status.UpdateProgress(value.FilePosition);
                status.UpdateOverallProgress(value.BatchPosition);

                // If you were doing a console application, you might write out something along the lines of:
                System.Diagnostics.Debug.WriteLine("Batch Progress " + ((value.BatchPosition * 100) / value.BatchLength).ToString() + "% File #" + (value.BatchFileIndex + 1).ToString() + " of " + value.BatchFileCount.ToString() +
                  " File progress " + value.Filename + " " + ((value.FilePosition * 100) / value.FileLength).ToString() + "%" + " Bytes copied = " + value.FilePosition.ToString());
            });

            status.Show();

            int bufferSize = 81920;
            if (int.TryParse(BufferSizeComboBox.Text, out bufferSize))
            {
                await FileIO.CopyFilesAsync(sourceFilesToDestinationMap, bufferSize, progress, status.CancellationToken);
            }
            else
            {
                MessageBox.Show("Select a value for the buffersize to use. 81920 is the default value used internally for .NET");
            }

            status.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AsynchronousBatchFileCopy_Load(object sender, EventArgs e)
        {
            BufferSizeComboBox.SelectedIndex = 1; // Default to the .NET Standard Value
        }
    }
}

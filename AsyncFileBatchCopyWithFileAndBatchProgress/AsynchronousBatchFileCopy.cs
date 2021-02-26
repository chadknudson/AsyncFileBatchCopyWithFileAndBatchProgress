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
                status.CurrentItemCaption = "Copying " + value.Filename;

                status.ItemMaximum = value.FileLength;
                status.ItemCurrent = value.FilePosition;

                status.UpdateProgress(value.FilePosition);
                status.UpdateOverallProgress(value.BatchPosition);

                // If you were doing a console application, you might write out something along the lines of:
                // Console.WriteLine("Batch Progress " + ((value.BatchPosition * 100) / value.BatchLength).ToString() + "% File progress " + value.Filename + " " + ((value.FilePosition * 100) / value.FileLength).ToString() + "%");
            });

            status.Show();

            await FileIO.CopyFilesAsync(sourceFilesToDestinationMap, progress, status.CancellationToken);

            status.Close();
        }
    }
}

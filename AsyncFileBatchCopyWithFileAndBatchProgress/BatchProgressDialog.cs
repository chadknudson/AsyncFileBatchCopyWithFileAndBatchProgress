using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    public partial class BatchProgressDialog : Form
    {
        public long ItemMaximum { get; set; }

        public long ItemCurrent { get; set; }

        public long OverallMaximum { get; set; }

        public CancellationTokenSource source = new CancellationTokenSource();

        public CancellationToken CancellationToken
        {
            get { return source.Token; }
        }

        public BatchProgressDialog()
        {
            InitializeComponent();
            ItemProgressBar.Minimum = 0;
            ItemProgressBar.Maximum = 100;
            OverallProgressBar.Minimum = 0;
            OverallProgressBar.Maximum = 100;
        }

        public BatchProgressDialog(int max)
        {
            ItemProgressBar.Maximum = max;
        }

        public void UpdateProgress()
        {
            ItemCurrent++;
        }

        public void UpdateProgress(long value)
        {
            ItemProgressBar.Value = (int)((value * 100) / ItemMaximum);
            ItemProgressBar.Invalidate();
        }

        public void UpdateOverallProgress(long value)
        {
            OverallProgressBar.Value = (int)((value * 100) / OverallMaximum);
            OverallProgressBar.Invalidate();
        }

        public string CurrentItemCaption
        {
            get
            {
                return CurrentItemLabel.Text;
            }
            set
            {
                CurrentItemLabel.Text = value;
            }
        }

        public string OverallProgressCaption
        {
            get
            {
                return CurrentItemLabel.Text;
            }
            set
            {
                CurrentItemLabel.Text = value;
            }
        }

        private void DialogStatus_Load(object sender, EventArgs e)
        {

        }

        private void DialogStatus_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://www.norsetechnologies.com";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            source.Cancel();
        }
    }
}

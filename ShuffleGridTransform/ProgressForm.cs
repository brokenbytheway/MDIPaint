using System;
using System.Threading;
using System.Windows.Forms;

namespace ShuffleGridTransform
{
    public partial class ProgressForm : Form
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        public IProgress<int> Progress { get; }

        public ProgressForm(CancellationTokenSource cancellationTokenSource)
        {
            InitializeComponent();
            _cancellationTokenSource = cancellationTokenSource;
            Progress = new Progress<int>(UpdateProgress);
        }

        private void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgress), value);
                return;
            }

            progressBar.Value = value;
            labelProgress.Text = $"{value}%";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            labelProgress.Text = "0%";
        }
    }
}
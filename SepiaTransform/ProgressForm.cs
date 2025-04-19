using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SepiaTransform
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

        public static void RunOperationWithProgress(
            Action<IProgress<int>, CancellationToken> operation,
            string title = "Обработка")
        {
            using (var cts = new CancellationTokenSource())
            using (var form = new ProgressForm(cts))
            {
                form.Text = title;
                form.Shown += async (s, e) =>
                {
                    try
                    {
                        await Task.Run(() => operation(form.Progress, cts.Token));
                        form.Close();
                    }
                    catch (OperationCanceledException)
                    {
                        form.Close();
                    }
                };
                form.ShowDialog();
            }
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SepiaTransform
{
    public partial class SepiaSettingsForm : Form
    {
        public float Intensity { get; private set; } = 0.5f;
        private Bitmap originalImage;
        private Bitmap previewImage;
        private CancellationTokenSource _previewCancellationTokenSource;

        public SepiaSettingsForm(Bitmap image)
        {
            InitializeComponent();
            originalImage = (Bitmap)image.Clone();
            trackBarIntensity.Value = 50;
            UpdatePreview();
        }

        private void trackBarIntensity_Scroll(object sender, EventArgs e)
        {
            labelValue.Text = (trackBarIntensity.Value / 100f).ToString("0.00");
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (originalImage == null) return;

            _previewCancellationTokenSource?.Cancel();
            _previewCancellationTokenSource = new CancellationTokenSource();

            float intensity = trackBarIntensity.Value / 100f;
            var tempImage = (Bitmap)originalImage.Clone();

            Task.Run(() =>
            {
                try
                {
                    var result = ApplySepiaParallel(tempImage, intensity, _previewCancellationTokenSource.Token);
                    if (!_previewCancellationTokenSource.IsCancellationRequested)
                    {
                        this.Invoke(new Action(() =>
                        {
                            previewImage?.Dispose();
                            previewImage = result;
                            previewPictureBox.Image = previewImage;
                        }));
                    }
                    else
                    {
                        tempImage.Dispose();
                    }
                }
                catch (OperationCanceledException)
                {
                    tempImage.Dispose();
                }
            });
        }

        private Bitmap ApplySepiaParallel(Bitmap bitmap, float intensity, CancellationToken cancellationToken)
        {
            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            try
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bmpData.Height;
                int widthInBytes = bmpData.Width * bytesPerPixel;

                unsafe
                {
                    byte* ptrFirstPixel = (byte*)bmpData.Scan0;

                    Parallel.For(0, heightInPixels, new ParallelOptions
                    {
                        CancellationToken = cancellationToken,
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    }, y =>
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return;

                        byte* currentLine = ptrFirstPixel + (y * bmpData.Stride);
                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            byte oldBlue = currentLine[x];
                            byte oldGreen = currentLine[x + 1];
                            byte oldRed = currentLine[x + 2];

                            int gray = (int)(0.3 * oldRed + 0.59 * oldGreen + 0.11 * oldBlue);

                            currentLine[x] = (byte)Clamp(gray - (int)(20 * intensity));    // Blue
                            currentLine[x + 1] = (byte)Clamp(gray + (int)(20 * intensity)); // Green
                            currentLine[x + 2] = (byte)Clamp(gray + (int)(40 * intensity)); // Red
                        }
                    });
                }
                return bitmap;
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _previewCancellationTokenSource?.Cancel();
            Intensity = trackBarIntensity.Value / 100f;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _previewCancellationTokenSource?.Cancel();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _previewCancellationTokenSource?.Cancel();
            originalImage?.Dispose();
            previewImage?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
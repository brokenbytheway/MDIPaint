using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastTransform
{
    public partial class ContrastSettingsForm : Form
    {
        public float ContrastValue { get; private set; } = 1.0f;
        private Bitmap originalImage;
        private Bitmap previewImage;
        private CancellationTokenSource _previewCancellationTokenSource;

        public ContrastSettingsForm(Bitmap image)
        {
            InitializeComponent();
            originalImage = (Bitmap)image.Clone();
            trackBarContrast.Value = 100;
            UpdatePreview();
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            labelValue.Text = ((float)trackBarContrast.Value / 100f).ToString("0.00");
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (originalImage == null) return;

            // Отменяем предыдущую операцию предпросмотра, если она была
            _previewCancellationTokenSource?.Cancel();
            _previewCancellationTokenSource = new CancellationTokenSource();

            float contrast = trackBarContrast.Value / 100f;
            var tempImage = (Bitmap)originalImage.Clone();

            // Запускаем асинхронную обработку для предпросмотра
            Task.Run(() =>
            {
                try
                {
                    var result = ApplyContrastParallel(tempImage, contrast, _previewCancellationTokenSource.Token);
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

        private Bitmap ApplyContrastParallel(Bitmap bitmap, float contrast, CancellationToken cancellationToken)
        {
            BitmapData bmpData = null;
            try
            {
                bmpData = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite,
                    bitmap.PixelFormat);

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
                            byte oldAlpha = bytesPerPixel == 4 ? currentLine[x + 3] : (byte)255;

                            double t = (1 - contrast) / 2;

                            int newRed = (int)(contrast * oldRed + t * 255);
                            int newGreen = (int)(contrast * oldGreen + t * 255);
                            int newBlue = (int)(contrast * oldBlue + t * 255);

                            newRed = Math.Max(0, Math.Min(255, newRed));
                            newGreen = Math.Max(0, Math.Min(255, newGreen));
                            newBlue = Math.Max(0, Math.Min(255, newBlue));

                            currentLine[x] = (byte)newBlue;
                            currentLine[x + 1] = (byte)newGreen;
                            currentLine[x + 2] = (byte)newRed;
                            if (bytesPerPixel == 4)
                                currentLine[x + 3] = oldAlpha;
                        }
                    });
                }
                return bitmap;
            }
            catch
            {
                // В случае ошибки возвращаем оригинальное изображение
                return (Bitmap)bitmap.Clone();
            }
            finally
            {
                if (bmpData != null && bitmap != null)
                {
                    try
                    {
                        bitmap.UnlockBits(bmpData);
                    }
                    catch (Exception ex)
                    {
                        // Логируем ошибку, но не прерываем выполнение
                        Console.WriteLine($"Ошибка при UnlockBits: {ex.Message}");
                    }
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _previewCancellationTokenSource?.Cancel();
            ContrastValue = trackBarContrast.Value / 100f;
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
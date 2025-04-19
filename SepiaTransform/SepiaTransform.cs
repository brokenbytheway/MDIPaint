using PluginInterface;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SepiaTransform
{
    [Version(1, 0)]
    public class SepiaTransform : IPlugin
    {
        public string Name => "Оттенки сепии";
        public string Author => "Me";

        private CancellationTokenSource _cancellationTokenSource;
        private ProgressForm _progressForm;

        public void Transform(Bitmap bitmap, ref bool isModified)
        {
            using (var form = new SepiaSettingsForm(bitmap))
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                float intensity = form.Intensity;

                ProgressForm.RunOperationWithProgress((progress, ct) =>
                {
                    ApplySepiaToImageFast(bitmap, intensity, progress, ct);
                }, "Применение сепии");

                isModified = true;
            }
        }

        private void ApplySepiaToImageFast(Bitmap bitmap, float intensity, IProgress<int> progress, CancellationToken cancellationToken)
        {
            // Блокируем битмап для безопасного доступа из нескольких потоков
            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            try
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int byteCount = bmpData.Stride * bitmap.Height;
                byte[] pixels = new byte[byteCount];
                int heightInPixels = bmpData.Height;
                int widthInPixels = bmpData.Width;
                int totalPixels = bitmap.Width * bitmap.Height;
                int processedPixels = 0;
                int lastReportedProgress = -1;

                // Копируем данные в массив
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, byteCount);

                Parallel.For(0, heightInPixels, new ParallelOptions
                {
                    CancellationToken = cancellationToken,
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                }, y =>
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    int currentY = y;
                    int currentLine = currentY * bmpData.Stride;

                    for (int x = 0; x < widthInPixels; x++)
                    {
                        int xi = currentLine + x * bytesPerPixel;

                        // Получаем значения пикселей
                        byte oldBlue = pixels[xi];
                        byte oldGreen = pixels[xi + 1];
                        byte oldRed = pixels[xi + 2];

                        // Вычисляем оттенок серого
                        int gray = (int)(0.3 * oldRed + 0.59 * oldGreen + 0.11 * oldBlue);

                        // Применяем эффект сепии
                        int newRed = Clamp(gray + (int)(40 * intensity));
                        int newGreen = Clamp(gray + (int)(20 * intensity));
                        int newBlue = Clamp(gray - (int)(20 * intensity));

                        // Устанавливаем новые значения
                        pixels[xi] = (byte)newBlue;
                        pixels[xi + 1] = (byte)newGreen;
                        pixels[xi + 2] = (byte)newRed;

                        // Обновляем прогресс
                        int newProgress = (int)(Interlocked.Increment(ref processedPixels) * 100 / totalPixels);
                        if (newProgress != lastReportedProgress)
                        {
                            lastReportedProgress = newProgress;
                            progress?.Report(newProgress);
                        }
                    }
                });

                // Копируем данные обратно
                System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, byteCount);
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
    }
}
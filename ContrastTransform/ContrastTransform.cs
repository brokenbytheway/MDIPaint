using PluginInterface;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastTransform
{
    [Version(1, 0)]
    public class ContrastTransform : IPlugin
    {
        public string Name => "Изменение контрастности";
        public string Author => "Me";

        private CancellationTokenSource _cancellationTokenSource;
        private ProgressForm _progressForm;

        public void Transform(Bitmap bitmap, ref bool isModified)
        {
            using (var form = new ContrastSettingsForm(bitmap))
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                float contrast = form.ContrastValue;

                ProgressForm.RunOperationWithProgress((progress, ct) =>
                {
                    ApplyContrastToImageFast(bitmap, contrast, progress, ct);
                }, "Изменение контрастности");

                isModified = true;
            }
        }

        private void ApplyContrastToImageFast(Bitmap bitmap, float contrast, IProgress<int> progress, CancellationToken cancellationToken)
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
                        byte oldAlpha = bytesPerPixel == 4 ? pixels[xi + 3] : (byte)255;

                        double t = (1 - contrast) / 2;

                        // Применяем контраст
                        int newRed = (int)(contrast * oldRed + t * 255);
                        int newGreen = (int)(contrast * oldGreen + t * 255);
                        int newBlue = (int)(contrast * oldBlue + t * 255);

                        // Ограничиваем значения
                        newRed = Math.Max(0, Math.Min(255, newRed));
                        newGreen = Math.Max(0, Math.Min(255, newGreen));
                        newBlue = Math.Max(0, Math.Min(255, newBlue));

                        // Устанавливаем новые значения
                        pixels[xi] = (byte)newBlue;
                        pixels[xi + 1] = (byte)newGreen;
                        pixels[xi + 2] = (byte)newRed;
                        if (bytesPerPixel == 4)
                            pixels[xi + 3] = oldAlpha;

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
    }
}
using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuffleGridTransform
{
    [Version(1, 0)]
    public class ShuffleGridTransform : IPlugin
    {
        public string Name => "Разбить и перемешать 9 блоков";
        public string Author => "Me";

        private CancellationTokenSource _cancellationTokenSource;
        private ProgressForm _progressForm;

        public void Transform(Bitmap bitmap, ref bool isModified)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _progressForm = new ProgressForm(_cancellationTokenSource);
            _progressForm.Show();

            try
            {
                SafeShuffleBlocks(bitmap, _progressForm.Progress, _cancellationTokenSource.Token);
                isModified = true;

                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    _progressForm.Close();
                }
            }
            catch (OperationCanceledException)
            {
                // Пользователь отменил операцию
            }
            finally
            {
                _progressForm?.Close();
            }
        }

        private void SafeShuffleBlocks(Bitmap bitmap, IProgress<int> progress, CancellationToken ct)
        {
            int cols = 3;
            int rows = 3;
            int totalOperations = cols * rows * 2; // Копирование + вставка
            int completedOperations = 0;

            // 1. Подготовка блоков
            int blockWidth = bitmap.Width / cols;
            int blockHeight = bitmap.Height / rows;

            var blocks = new List<Rectangle>();
            for (int y = 0; y < rows; y++)
                for (int x = 0; x < cols; x++)
                    blocks.Add(new Rectangle(x * blockWidth, y * blockHeight, blockWidth, blockHeight));

            // 2. Перемешивание порядка блоков
            var rnd = new Random();
            var shuffled = new List<Rectangle>(blocks);
            for (int i = shuffled.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
            }

            // 3. Параллельное копирование блоков с прогрессом
            var blockImages = new Bitmap[blocks.Count];
            Parallel.For(0, blocks.Count, new ParallelOptions
            {
                CancellationToken = ct,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            }, i =>
            {
                ct.ThrowIfCancellationRequested();

                lock (bitmap)
                {
                    blockImages[i] = bitmap.Clone(blocks[i], bitmap.PixelFormat);
                }

                int progressValue = Interlocked.Increment(ref completedOperations) * 100 / totalOperations;
                progress?.Report(progressValue);
            });

            // 4. Создаем временный буфер для безопасной вставки
            using (var tempBitmap = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat))
            using (var g = Graphics.FromImage(tempBitmap))
            {
                // 5. Параллельная вставка блоков с прогрессом
                Parallel.For(0, blocks.Count, new ParallelOptions
                {
                    CancellationToken = ct,
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                }, i =>
                {
                    ct.ThrowIfCancellationRequested();

                    lock (g)
                    {
                        g.DrawImage(blockImages[i], shuffled[i]);
                    }

                    int progressValue = Interlocked.Increment(ref completedOperations) * 100 / totalOperations;
                    progress?.Report(progressValue);
                });

                // 6. Копируем результат обратно (в UI потоке)
                if (!ct.IsCancellationRequested)
                {
                    using (var gOriginal = Graphics.FromImage(bitmap))
                    {
                        gOriginal.DrawImage(tempBitmap, 0, 0);
                    }
                }
            }

            // 7. Очистка
            foreach (var img in blockImages)
                img?.Dispose();
        }
    }
}
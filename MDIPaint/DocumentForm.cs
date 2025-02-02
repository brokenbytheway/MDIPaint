using MDIPaint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class DocumentForm : Form
    {
        private int x, y, sX, sY, cX, cY;
        private Point px, py;
        private Bitmap bitmap;
        private Graphics graphics;
        private bool paint = false;
        public bool isModified = false;
        private MainForm mainform;
        public string CurrentFilePath { get; private set; }

        private void SetSize()
        {
            bitmap = new Bitmap(800, 450);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
            MainForm.pen.StartCap = LineCap.Round;
            MainForm.pen.EndCap = LineCap.Round;
            MainForm.eraser.StartCap = LineCap.Round;
            MainForm.eraser.EndCap = LineCap.Round;
        }

        public DocumentForm(MainForm parent)
        {
            InitializeComponent();
            SetSize();
            mainform = parent;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            sX = x - cX;
            sY = y - cY;

            if (MainForm.index == 6)
            {
                try
                {
                    graphics.DrawLine(MainForm.pen, cX, cY, x, y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (MainForm.index == 7)
            {
                try
                {
                    if (MainForm.FillShape)
                        graphics.FillEllipse(new SolidBrush(MainForm.pen.Color), cX, cY, sX, sY);
                    else
                        graphics.DrawEllipse(MainForm.pen, cX, cY, sX, sY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (MainForm.index == 8)
            {
                try
                {
                    int width = Math.Abs(x - cX);
                    int height = Math.Abs(y - cY);
                    if (width == 0 || height == 0)
                        return;

                    int left = Math.Min(x, cX);
                    int top = Math.Min(y, cY);
                    int radius = width / 4; // Радиус дуг (четверть ширины сердца)

                    // Определяем прямоугольники для дуг
                    Rectangle leftArcRect = new Rectangle(left, top, 2 * radius, 2 * radius);
                    Rectangle rightArcRect = new Rectangle(left + 2 * radius, top, 2 * radius, 2 * radius);

                    // Центральная точка соединения нижней части сердца
                    Point bottomPoint = new Point(left + 2 * radius, top + height);

                    // Левые и правые соединяющие точки
                    Point leftJoin = new Point(left, top + radius);
                    Point rightJoin = new Point(left + 4 * radius, top + radius);

                    // Рисуем две дуги
                    graphics.DrawArc(MainForm.pen, leftArcRect, 180, 180);
                    graphics.DrawArc(MainForm.pen, rightArcRect, 180, 180);

                    // Рисуем соединяющие линии
                    graphics.DrawLine(MainForm.pen, leftJoin, bottomPoint);
                    graphics.DrawLine(MainForm.pen, rightJoin, bottomPoint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (paint)
            {
                if (MainForm.index == 6)
                {
                    try
                    {
                        g.DrawLine(MainForm.pen, cX, cY, x, y);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (MainForm.index == 7)
                {
                    try
                    {
                        g.DrawEllipse(MainForm.pen, cX, cY, sX, sY);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (MainForm.index == 8)
                {
                    try
                    {
                        int width = Math.Abs(x - cX);
                        int height = Math.Abs(y - cY);
                        if (width == 0 || height == 0)
                            return;

                        int left = Math.Min(x, cX);
                        int top = Math.Min(y, cY);
                        int radius = width / 4; // Радиус дуг (четверть ширины сердца)

                        // Определяем прямоугольники для дуг
                        Rectangle leftArcRect = new Rectangle(left, top, 2 * radius, 2 * radius);
                        Rectangle rightArcRect = new Rectangle(left + 2 * radius, top, 2 * radius, 2 * radius);

                        // Центральная точка соединения нижней части сердца
                        Point bottomPoint = new Point(left + 2 * radius, top + height);

                        // Левые и правые соединяющие точки
                        Point leftJoin = new Point(left, top + radius);
                        Point rightJoin = new Point(left + 4 * radius, top + radius);

                        // Рисуем две дуги
                        g.DrawArc(MainForm.pen, leftArcRect, 180, 180);
                        g.DrawArc(MainForm.pen, rightArcRect, 180, 180);

                        // Рисуем соединяющие линии
                        g.DrawLine(MainForm.pen, leftJoin, bottomPoint);
                        g.DrawLine(MainForm.pen, rightJoin, bottomPoint);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static Point SetPoint(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MainForm.index == 3)
            {
                Point point = SetPoint(pictureBox1, e.Location);
                Fill(bitmap, point.X, point.Y, MainForm.pen.Color);
            }
            else if (MainForm.index == 4)
            {
                ShowTextBox(e.Location);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (MainForm.index == 1)
                {
                    try
                    {
                        px = e.Location;
                        graphics.DrawLine(MainForm.pen, px, py);
                        py = px;
                        SetStar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (MainForm.index == 2)
                {
                    try
                    {
                        px = e.Location;
                        graphics.DrawLine(MainForm.eraser, px, py);
                        py = px;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            pictureBox1.Invalidate();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    try
        //    {
        //        e.Graphics.DrawImage(bitmap, 0, 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при перерисовке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void Save(string path)
        {
            try
            {
                bitmap.Save(path);
                CurrentFilePath = path;
                isModified = false;
                this.Text = this.Text.TrimStart('*');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveAs(string path)
        {
            Save(path);
        }

        public void LoadFile(string path)
        {
            try
            {
                var image = new Bitmap(path);
                bitmap = new Bitmap(image);
                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
                CurrentFilePath = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTextBox(Point location)
        {
            TextBox textBox = new TextBox();
            textBox.Multiline = false;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Arial", 14);
            textBox.Location = pictureBox1.PointToClient(PointToScreen(location));
            textBox.Width = 100;

            textBox.LostFocus += (s, e) => { DrawText(textBox.Text, location); textBox.Dispose(); };
            textBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { DrawText(textBox.Text, location); textBox.Dispose(); } };

            this.Controls.Add(pictureBox1);
            this.Controls.Add(textBox);
            textBox.Focus();
            textBox.BringToFront();
        }

        private void DrawText(string text, Point location)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            Graphics g = Graphics.FromImage(bitmap);
            g.DrawString(text, new Font("Arial", 14), new SolidBrush(MainForm.pen.Color), location);
            pictureBox1.Invalidate();
            isModified = true;
        }

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                var choice = MessageBox.Show("Вы хотите сохранить изменения?", "Сохранить изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (choice == DialogResult.Yes)
                {
                    mainform.сохранитьToolStripMenuItem_Click(sender, e);
                }
                else if (choice == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

        }

        private void Validate(Bitmap bm, Stack<Point> sp, int x, int y, Color oldColor, Color newColor)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == oldColor)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, newColor);
            }
        }

        public void Fill(Bitmap bm, int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);

            if (oldColor == newColor)
            {
                return;
            }

            while (pixel.Count > 0)
            {
                Point point = pixel.Pop();
                if (point.X > 0 && point.Y > 0 && point.X < bm.Width - 1 && point.Y < bm.Height - 1)
                {
                    Validate(bm, pixel, point.X - 1, point.Y, oldColor, newColor);
                    Validate(bm, pixel, point.X, point.Y - 1, oldColor, newColor);
                    Validate(bm, pixel, point.X + 1, point.Y, oldColor, newColor);
                    Validate(bm, pixel, point.X, point.Y + 1, oldColor, newColor);
                }
            }
        }

        public void ResizeCanvas(int newWidth, int newHeight)
        {
            if (newWidth <= 0 || newHeight <= 0)
            {
                return;
            }

            Bitmap newBitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(newBitmap);
            g.Clear(Color.White);

            if (bitmap != null)
            {
                g.DrawImage(bitmap, 0, 0);
            }
            bitmap = newBitmap;
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            pictureBox1.Width = newWidth;
            pictureBox1.Height = newHeight;

            int formWidth = this.Width - this.ClientSize.Width;
            int formHeight = this.Height - this.ClientSize.Height;

            this.Width = newWidth + formWidth;
            this.Height = newHeight + formHeight;
        }

        public void ChangeCursor()
        {
            switch (MainForm.index)
            {
                case 2: // Ластик
                    pictureBox1.Cursor = Cursors.No;
                    break;
                case 3: // Заливка
                    pictureBox1.Cursor = Cursors.Arrow;
                    break;
                case 4: // Текст
                    pictureBox1.Cursor = Cursors.IBeam;
                    break;
                case 5: // Масштаб
                    pictureBox1.Cursor = Cursors.Arrow;
                    break;
                case 6: // Линия
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                case 7: // Эллипс
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                case 8: // Сердце
                    pictureBox1.Cursor = Cursors.Cross;
                    break;
                default:
                    pictureBox1.Cursor = Cursors.Default;
                    break;
            }
        }

        private void SetStar()
        {
            isModified = true;

            if (isModified && !this.Text.StartsWith("*"))
            {
                this.Text = "*" + this.Text;
            }
            else if (!isModified)
            {
                this.Text = this.Text.TrimStart('*', ' ');
            }
        }
    }
}

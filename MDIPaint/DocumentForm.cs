using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class DocumentForm : Form
    {
        private int x, y, sX, sY, cX, cY, _x, _y, _sX, _sY, _cX, _cY;
        private Point px, py, _px, _py;
        private Bitmap bitmap;
        private Graphics graphics;
        private bool paint = false;
        public bool isModified = false;
        public float scale = 1.0f;
        private int bmwidth = 800;
        private int bmheight = 450;
        private int _bmwidth = 800;
        private int _bmheight = 450;
        private Stack<Point> pixel = new Stack<Point>();
        public string currentFilePath;
        private Bitmap bitmapCursor;
        private IntPtr ptr;
        private Cursor cur;
        private TextBox textBox = null;
        private Point tbpoint;

        private void SetSize()
        {
            bitmap = new Bitmap(800, 450);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;

            bitmapCursor = new Bitmap(Properties.Resources._290133_art_brush_paint_painting_icon);
            ptr = bitmapCursor.GetHicon();
            cur = new Cursor(ptr);
            pictureBox1.Cursor = cur;
        }

        public DocumentForm(MainForm parent)
        {
            InitializeComponent();
            SetSize();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = _py = e.Location;
            x = cX = py.X;
            y = cY = py.Y;
            px = py;
            sX = 0;
            sY = 0;
            _x = _cX = _py.X = (int)(_py.X / scale);
            _y = _cY = _py.Y = (int)(_py.Y / scale);
            _px = _py;
            _sX = 0;
            _sY = 0;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            MainForm.pen.Width = MainForm.penAndEraserWidth * scale;

            if (MainForm.index == 6)
            {
                try
                {
                    graphics.DrawLine(MainForm.pen, _cX, _cY, _x, _y);
                    pictureBox1.Invalidate();
                    SetStar();
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
                    {
                        graphics.FillEllipse(new SolidBrush(MainForm.pen.Color), _cX, _cY, _sX, _sY);
                    }
                    else
                    {
                        graphics.DrawEllipse(MainForm.pen, _cX, _cY, _sX, _sY);
                    }
                    pictureBox1.Invalidate();
                    SetStar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (MainForm.index == 8)
            {
                List<PointF> points = new List<PointF>(361);
                try
                {
                    if (MainForm.FillShape)
                    {
                        Color color = MainForm.pen.Color;
                        Color tc = Color.FromArgb(255, 255, 254);
                        MainForm.pen.Color = tc;
                        DrawHeart(_cX, _cY, _sX, _sY, points);
                        graphics.TranslateTransform(_sX / 2, _sY / 2);
                        float w = MainForm.pen.Width;
                        MainForm.pen.Width += 1;
                        graphics.DrawLines(MainForm.pen, points.ToArray());
                        MainForm.pen.Width = w;
                        graphics.ResetTransform();
                        int cx = (int)(points[0].X);
                        if (cx < 0) { cx = 0; } else if (cx >= bmwidth) { cx = bmwidth - 1; }
                        int cy = ((int)(points[0].Y) + (int)(points[180].Y)) / 2 + _sY;
                        if (cy < 0) { cy = 0; } else if (cy >= bmheight) { cy = bmheight - 1; }
                        FillHeart(bitmap, cx, cy, tc);

                        MainForm.pen.Color = color;
                        Fill(bitmap, cx, cy, color);
                        //graphics.FillEllipse(new SolidBrush(Color.Red), cx - 2, cy - 2, 5, 5);
                    }
                    else
                    {
                        DrawHeart(_cX, _cY, _sX, _sY, points);
                        graphics.TranslateTransform(_sX / 2, _sY / 2);
                        graphics.DrawLines(MainForm.pen, points.ToArray());
                        graphics.ResetTransform();
                    }
                    pictureBox1.Invalidate();
                    SetStar();
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
            MainForm.pen.Width = MainForm.penAndEraserWidth * scale;

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
                        if (MainForm.FillShape)
                        {
                            g.FillEllipse(new SolidBrush(MainForm.pen.Color), cX, cY, sX, sY);
                        }
                        else
                        {
                            g.DrawEllipse(MainForm.pen, cX, cY, sX, sY);
                        }
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
                        List<PointF> points = new List<PointF>(361);
                        DrawHeart(cX, cY, sX, sY, points);
                        g.TranslateTransform(sX / 2, sY / 2);
                        g.DrawLines(MainForm.pen, points.ToArray());
                        g.ResetTransform();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawHeart(int x, int y, int width, int height, List<PointF> points)
        {
            float q = 0.5f;
            float scale_x = width / 2;
            float scale_y = height / 2;
            for (int t = 0; t <= 360; t++)
            {
                double love = Math.PI * t / 180;
                float y1 = (float)(Math.Sin(love) + Math.Pow(Math.Abs(Math.Cos(love)), q));
                float x1 = (float)Math.Cos(love);
                points.Add(new PointF(x + x1 * scale_x, y + -y1 * scale_y));
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MainForm.index == 3)
            {
                Fill(bitmap, _cX, _cY, MainForm.pen.Color);
            }
            else if (MainForm.index == 4)
            {
                ShowTextBox(e.Location);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            px = e.Location;
            x = (int)(px.X);
            y = (int)(px.Y);
            sX = x - cX;
            sY = y - cY;
            _px = e.Location;
            _x = _px.X = (int)(_px.X / scale);
            _y = _px.Y = (int)(_px.Y / scale);
            _sX = _x - _cX;
            _sY = _y - _cY;

            if (!paint)
            {
                return;
            }
            else
            {
                MainForm.pen.Width = MainForm.penAndEraserWidth * scale;
                MainForm.eraser.Width = MainForm.penAndEraserWidth * scale;
                if (MainForm.index == 1)
                {
                    try
                    {
                        graphics.DrawLine(MainForm.pen, _px, _py);
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
                        graphics.DrawLine(MainForm.eraser, _px, _py);
                        SetStar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при рисовании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            py = px;
            _py = _px;
            pictureBox1.Invalidate();
        }

        public void Save(string path)
        {
            paint = false;
            try
            {
                bitmap.Save(path);
                currentFilePath = path;
                isModified = false;
                UpdateTitle();
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
                paint = false;
                scale = 1.0f;
                isModified = false;
                var image = new Bitmap(path);
                bitmap = new Bitmap(image);
                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
                bmwidth = _bmwidth = bitmap.Width;
                bmheight = _bmheight = bitmap.Height;
                currentFilePath = path;
                ResizeImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTextBox(Point location)
        {
            MainForm.pen.Width = MainForm.penAndEraserWidth * scale;
            if (textBox != null)
            {
                textBox.Dispose();
            }

            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.AutoSize = true;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Arial", 14 * scale);
            Point p = pictureBox1.PointToClient(PointToScreen(location));
            textBox.Location = location;
            textBox.Width = (int)(100 * scale);
            p = location;
            p.X = (int)(p.X / scale);
            p.Y = (int)(p.Y / scale);
            tbpoint = p;

            textBox.LostFocus += (s, e) => { DrawText(textBox.Text); textBox.Dispose(); };
            textBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { DrawText(textBox.Text); textBox.Dispose(); } };

            this.Controls.Add(textBox);
            textBox.Focus();
            textBox.BringToFront();
        }

        private void DrawText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            graphics.DrawString(text, new Font("Arial", 14), new SolidBrush(MainForm.pen.Color), tbpoint);
            pictureBox1.Invalidate();
            SetStar();
        }

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                string fileName = string.IsNullOrEmpty(currentFilePath) ? "Безымянный рисунок" : Path.GetFileName(currentFilePath);
                var choice = MessageBox.Show($"Вы хотите сохранить изменения в файле \"{fileName}\"?", "Сохранить изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (choice == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(currentFilePath))
                    {
                        SaveFileDialog saveDialog = new SaveFileDialog();
                        saveDialog.Filter = "JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            Save(saveDialog.FileName);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        Save(currentFilePath);
                    }
                }
                else if (choice == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ValidateHeart(Bitmap bm, int x, int y, Color newColor)
        {
            if (x >= 0 && y >= 0 && x < bm.Width && y < bm.Height)
            {
                Color c = bm.GetPixel(x, y);
                if (c.ToArgb() != newColor.ToArgb())
                {
                    pixel.Push(new Point(x, y));
                    bm.SetPixel(x, y, newColor);
                }
            }
        }

        private void FillHeart(Bitmap bm, int x, int y, Color newColor)
        {
            Point point;
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            Color c = bm.GetPixel(x, y);

            while (pixel.Count > 0)
            {
                point = pixel.Pop();
                if (point.X >= 0 && point.Y >= 0 && point.X < bm.Width && point.Y < bm.Height)
                {
                    ValidateHeart(bm, point.X - 1, point.Y, newColor);
                    ValidateHeart(bm, point.X, point.Y - 1, newColor);
                    ValidateHeart(bm, point.X + 1, point.Y, newColor);
                    ValidateHeart(bm, point.X, point.Y + 1, newColor);
                }
            }
            pictureBox1.Invalidate();
            SetStar();
        }

        private void Validate(Bitmap bm, Stack<Point> sp, int x, int y, Color oldColor, Color newColor)
        {
            if (x >= 0 && y >= 0 && x < bm.Width && y < bm.Height)
            {
                Color cx = bm.GetPixel(x, y);
                if (cx.ToArgb() == oldColor.ToArgb())
                {
                    sp.Push(new Point(x, y));
                    bm.SetPixel(x, y, newColor);
                }
            }
        }

        public void Fill(Bitmap bm, int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);

            if (oldColor.ToArgb() == newColor.ToArgb())
            {
                return;
            }

            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            while (pixel.Count > 0)
            {
                Point point = pixel.Pop();
                if (point.X >= 0 && point.Y >= 0 && point.X < bm.Width && point.Y < bm.Height)
                {
                    Validate(bm, pixel, point.X - 1, point.Y, oldColor, newColor);
                    Validate(bm, pixel, point.X, point.Y - 1, oldColor, newColor);
                    Validate(bm, pixel, point.X + 1, point.Y, oldColor, newColor);
                    Validate(bm, pixel, point.X, point.Y + 1, oldColor, newColor);
                }
            }
            pictureBox1.Invalidate();
            SetStar();
        }

        public void ResizeCanvas(int newWidth, int newHeight)
        {
            if (newWidth <= 0 || newHeight <= 0)
            {
                return;
            }

            int formWidth = this.Width - this.ClientSize.Width;
            int formHeight = this.Height - this.ClientSize.Height;
            bmwidth = _bmwidth = newWidth;
            bmheight = _bmheight = newHeight;
            Bitmap newBitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(newBitmap);
            g.Clear(Color.White);

            if (bitmap != null)
            {
                //g.DrawImage(bitmap, 0, 0);
                g.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            bitmap = newBitmap;
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            pictureBox1.Width = (int)(newWidth * scale);
            pictureBox1.Height = (int)(newHeight * scale);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            this.Width = (int)(newWidth * scale) + formWidth;
            this.Height = (int)(newHeight * scale) + formHeight;

            pictureBox1.Invalidate();
        }

        public void ChangeCursor()
        {
            switch (MainForm.index)
            {
                case 1: // Кисть
                    bitmapCursor = new Bitmap(Properties.Resources._290133_art_brush_paint_painting_icon);
                    ptr = bitmapCursor.GetHicon();
                    cur = new Cursor(ptr);
                    pictureBox1.Cursor = cur;
                    break;
                case 2: // Ластик
                    bitmapCursor = new Bitmap(Properties.Resources._9025873_square_icon);
                    ptr = bitmapCursor.GetHicon();
                    cur = new Cursor(ptr);
                    pictureBox1.Cursor = cur;
                    break;
                case 3: // Заливка
                    bitmapCursor = new Bitmap(Properties.Resources._9025742_paint_bucket_icon1);
                    ptr = bitmapCursor.GetHicon();
                    cur = new Cursor(ptr);
                    pictureBox1.Cursor = cur;
                    break;
                case 4: // Текст
                    pictureBox1.Cursor = Cursors.IBeam;
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

        private void ResizeImage()
        {
            if (bitmap == null) return;

            int formWidth = this.Width - this.ClientSize.Width;
            int formHeight = this.Height - this.ClientSize.Height;
            if (textBox != null)
            {
                textBox.Width = (int)(100 * scale);
                textBox.Font = new Font("Arial", 14 * scale);
                Point p = tbpoint;
                p.X = (int)(p.X * scale);
                p.Y = (int)(p.Y * scale);
                textBox.Location = p;
            }

            int newWidth = (int)(_bmwidth * scale);
            int newHeight = (int)(_bmheight * scale);

            pictureBox1.Width = newWidth;
            pictureBox1.Height = newHeight;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            this.Width = newWidth + formWidth;
            this.Height = newHeight + formHeight;

            pictureBox1.Invalidate();
        }

        public void ZoomIn()
        {
            scale += 0.1f;
            ResizeImage();
        }

        public void ZoomOut()
        {
            if (scale > 0.1f)
            {
                scale -= 0.1f;
                ResizeImage();
            }
        }

        public void UpdateTitle()
        {
            this.Text = string.IsNullOrEmpty(currentFilePath) ? "Безымянный рисунок" : Path.GetFileName(currentFilePath);
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }
    }
}

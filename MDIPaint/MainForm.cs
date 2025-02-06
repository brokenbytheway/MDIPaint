using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MDIPaint
{
    public partial class MainForm : Form
    {
        public static Pen pen = new Pen(Color.Black, 1f);
        public static Pen eraser = new Pen(Color.White, 1f);
        public static float penAndEraserWidth = 1f;
        public static int index = 1;
        public static bool FillShape = false;

        public MainForm()
        {
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            eraser.StartCap = LineCap.Round;
            eraser.EndCap = LineCap.Round;
            InitializeComponent();
            this.MdiChildActivate += MainForm_MdiChildActivate;
            UpdateToolStrip();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                var d = child as DocumentForm;
                if (d != null && d.isModified)
                {
                    d.isModified = false;
                    string fileName = string.IsNullOrEmpty(d.currentFilePath) ? "Безымянный рисунок" : Path.GetFileName(d.currentFilePath);
                    var result = MessageBox.Show($"Вы хотите сохранить изменения в файле \"{fileName}\"?", "Сохранить изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(d.currentFilePath))
                        {
                            var dlg = new SaveFileDialog();
                            dlg.Filter = "JPEG Image (*.jpg)|*.jpg|Bitmap Image (.bmp)|*.bmp";
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    d.SaveAs(dlg.FileName);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                if (d.isModified)
                                {
                                    d.Save(d.currentFilePath);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        d.Close();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DocumentForm(this);
            frm.MdiParent = this;
            frm.UpdateTitle();
            frm.Show();
        }

        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            if (d != null)
            {
                var canvasForm = new CanvasSizeForm();
                if (canvasForm.ShowDialog() == DialogResult.OK)
                {
                    d.ResizeCanvas(canvasForm.CanvasWidth, canvasForm.CanvasHeight);
                }
            }
        }

        private void черныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                pen.Color = cd.Color;
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;

            if (d != null)
            {
                if (string.IsNullOrEmpty(d.currentFilePath))
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    try
                    {
                        if (d.isModified)
                        {
                            d.Save(d.currentFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;

            if (d != null)
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = "JPEG Image (*.jpg)|*.jpg|Bitmap Image (.bmp)|*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        d.SaveAs(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void файлToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void окноToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            каскадомToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            слеваНаправоToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сверхуВнизToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            упорядочитьЗначкиToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            penAndEraserWidth = trackBar1.Value;
            pen.Width = penAndEraserWidth;
            eraser.Width = penAndEraserWidth;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "JPEG Image (*.jpeg, *.jpg)|*.jpeg;*.jpg|Bitmap Image (.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newDoc = new DocumentForm(this);
                    newDoc.MdiParent = this;
                    newDoc.LoadFile(dlg.FileName);
                    newDoc.UpdateTitle();
                    newDoc.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void brushButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 1;
            d.ChangeCursor();
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 2;
            d.ChangeCursor();
        }

        private void bucketButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 3;
            d.ChangeCursor();
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 4;
            d.ChangeCursor();
        }

        private void zoomButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            d.ZoomIn();
        }

        private void nozoomButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            d.ZoomOut();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 6;
            d.ChangeCursor();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 7;
            d.ChangeCursor();
        }

        private void heartButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            index = 8;
            d.ChangeCursor();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.FillShape = checkBox1.Checked;
        }

        private void UpdateToolStrip()
        {
            toolStripDropDownButton1.Enabled = !(ActiveMdiChild == null);
            brushButton.Enabled = !(ActiveMdiChild == null);
            eraserButton.Enabled = !(ActiveMdiChild == null);
            bucketButton.Enabled = !(ActiveMdiChild == null);
            textButton.Enabled = !(ActiveMdiChild == null);
            zoomButton.Enabled = !(ActiveMdiChild == null);
            lineButton.Enabled = !(ActiveMdiChild == null);
            ellipseButton.Enabled = !(ActiveMdiChild == null);
            heartButton.Enabled = !(ActiveMdiChild == null);
            trackBar1.Enabled = !(ActiveMdiChild == null);
            checkBox1.Enabled = !(ActiveMdiChild == null);
            nozoomButton.Enabled = !(ActiveMdiChild == null);
            clearButton.Enabled = !(ActiveMdiChild == null);
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            UpdateToolStrip();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            d.Clear();
        }
    }
}

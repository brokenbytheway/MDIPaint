using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MDIPaint
{
    public partial class CanvasSizeForm : Form
    {
        public int CanvasWidth { get; private set; }
        public int CanvasHeight { get; private set; }

        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (int.TryParse(textBox1.Text, out int newWidth) && int.TryParse(textBox2.Text, out int newHeight) && newWidth > 0 && newHeight > 0)
            {
                CanvasWidth = newWidth;
                CanvasHeight = newHeight;
                return true;
            }
            else
            {
                MessageBox.Show("Введите корректные значения ширины и высоты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

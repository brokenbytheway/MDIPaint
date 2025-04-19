using System.Windows.Forms;

namespace SepiaTransform
{
    partial class SepiaSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TrackBar trackBarIntensity;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox previewPictureBox;

        private void InitializeComponent()
        {
            this.trackBarIntensity = new System.Windows.Forms.TrackBar();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarIntensity
            // 
            this.trackBarIntensity.Location = new System.Drawing.Point(20, 30);
            this.trackBarIntensity.Maximum = 100;
            this.trackBarIntensity.Minimum = 0;
            this.trackBarIntensity.Name = "trackBarIntensity";
            this.trackBarIntensity.Size = new System.Drawing.Size(200, 45);
            this.trackBarIntensity.TabIndex = 0;
            this.trackBarIntensity.TickFrequency = 10;
            this.trackBarIntensity.Value = 50;
            this.trackBarIntensity.Scroll += new System.EventHandler(this.trackBarIntensity_Scroll);
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(20, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(100, 23);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Интенсивность:";
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(230, 30);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(50, 23);
            this.labelValue.TabIndex = 2;
            this.labelValue.Text = "0.50";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(40, 300);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(130, 300);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPictureBox.Location = new System.Drawing.Point(20, 80);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(300, 200);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 5;
            this.previewPictureBox.TabStop = false;
            // 
            // SepiaSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(340, 340);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.trackBarIntensity);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SepiaSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сепия — настройка";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
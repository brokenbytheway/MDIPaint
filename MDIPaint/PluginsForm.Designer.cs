namespace MDIPaint
{
    partial class PluginsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pluginsDataGridView = new System.Windows.Forms.DataGridView();
            this.autoLoadCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.enabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pluginsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pluginsDataGridView
            // 
            this.pluginsDataGridView.AllowUserToAddRows = false;
            this.pluginsDataGridView.AllowUserToDeleteRows = false;
            this.pluginsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pluginsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledColumn,
            this.nameColumn,
            this.authorColumn,
            this.versionColumn});
            this.pluginsDataGridView.Location = new System.Drawing.Point(12, 35);
            this.pluginsDataGridView.Name = "pluginsDataGridView";
            this.pluginsDataGridView.RowHeadersVisible = false;
            this.pluginsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pluginsDataGridView.Size = new System.Drawing.Size(560, 250);
            this.pluginsDataGridView.TabIndex = 0;
            // 
            // autoLoadCheckBox
            // 
            this.autoLoadCheckBox.AutoSize = true;
            this.autoLoadCheckBox.Location = new System.Drawing.Point(12, 12);
            this.autoLoadCheckBox.Name = "autoLoadCheckBox";
            this.autoLoadCheckBox.Size = new System.Drawing.Size(235, 17);
            this.autoLoadCheckBox.TabIndex = 1;
            this.autoLoadCheckBox.Text = "Автоматическая загрузка всех плагинов";
            this.autoLoadCheckBox.UseVisualStyleBackColor = true;
            this.autoLoadCheckBox.CheckedChanged += new System.EventHandler(this.autoLoadCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(416, 291);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(497, 291);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // enabledColumn
            // 
            this.enabledColumn.HeaderText = "Включен";
            this.enabledColumn.Name = "enabledColumn";
            this.enabledColumn.Width = 60;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Название";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 120;
            // 
            // authorColumn
            // 
            this.authorColumn.HeaderText = "Автор";
            this.authorColumn.Name = "authorColumn";
            this.authorColumn.ReadOnly = true;
            this.authorColumn.Width = 120;
            // 
            // versionColumn
            // 
            this.versionColumn.HeaderText = "Версия";
            this.versionColumn.Name = "versionColumn";
            this.versionColumn.ReadOnly = true;
            this.versionColumn.Width = 60;
            // 
            // PluginsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(584, 326);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.autoLoadCheckBox);
            this.Controls.Add(this.pluginsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление плагинами";
            ((System.ComponentModel.ISupportInitialize)(this.pluginsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView pluginsDataGridView;
        private System.Windows.Forms.CheckBox autoLoadCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionColumn;
    }
}
namespace MDIPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерХолстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваНаправоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуВнизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядочитьЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.черныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.красныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зеленыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.bucketButton = new System.Windows.Forms.ToolStripButton();
            this.textButton = new System.Windows.Forms.ToolStripButton();
            this.zoomButton = new System.Windows.Forms.ToolStripButton();
            this.nozoomButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseButton = new System.Windows.Forms.ToolStripButton();
            this.heartButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.окноToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripSeparator2,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.DropDownOpening += new System.EventHandler(this.файлToolStripMenuItem_DropDownOpening);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерХолстаToolStripMenuItem});
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            this.рисунокToolStripMenuItem.DropDownOpening += new System.EventHandler(this.рисунокToolStripMenuItem_DropDownOpening);
            // 
            // размерХолстаToolStripMenuItem
            // 
            this.размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            this.размерХолстаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.размерХолстаToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.размерХолстаToolStripMenuItem.Text = "Размер холста...";
            this.размерХолстаToolStripMenuItem.Click += new System.EventHandler(this.размерХолстаToolStripMenuItem_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.слеваНаправоToolStripMenuItem,
            this.сверхуВнизToolStripMenuItem,
            this.упорядочитьЗначкиToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.окноToolStripMenuItem.Text = "Окно";
            this.окноToolStripMenuItem.DropDownOpening += new System.EventHandler(this.окноToolStripMenuItem_DropDownOpening);
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.каскадомToolStripMenuItem.Text = "Каскадом";
            this.каскадомToolStripMenuItem.Click += new System.EventHandler(this.каскадомToolStripMenuItem_Click);
            // 
            // слеваНаправоToolStripMenuItem
            // 
            this.слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            this.слеваНаправоToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.слеваНаправоToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.слеваНаправоToolStripMenuItem.Text = "Слева направо";
            this.слеваНаправоToolStripMenuItem.Click += new System.EventHandler(this.слеваНаправоToolStripMenuItem_Click);
            // 
            // сверхуВнизToolStripMenuItem
            // 
            this.сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            this.сверхуВнизToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.сверхуВнизToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.сверхуВнизToolStripMenuItem.Text = "Сверху вниз";
            this.сверхуВнизToolStripMenuItem.Click += new System.EventHandler(this.сверхуВнизToolStripMenuItem_Click);
            // 
            // упорядочитьЗначкиToolStripMenuItem
            // 
            this.упорядочитьЗначкиToolStripMenuItem.Name = "упорядочитьЗначкиToolStripMenuItem";
            this.упорядочитьЗначкиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.упорядочитьЗначкиToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.упорядочитьЗначкиToolStripMenuItem.Text = "Упорядочить значки";
            this.упорядочитьЗначкиToolStripMenuItem.Click += new System.EventHandler(this.упорядочитьЗначкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.brushButton,
            this.eraserButton,
            this.bucketButton,
            this.textButton,
            this.zoomButton,
            this.nozoomButton,
            this.toolStripSeparator5,
            this.toolStripLabel3,
            this.lineButton,
            this.ellipseButton,
            this.heartButton,
            this.toolStripSeparator6,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(835, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 47);
            this.toolStripLabel1.Text = "Цвет:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(86, 47);
            this.toolStripLabel2.Text = "Инструменты:";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(53, 47);
            this.toolStripLabel3.Text = "Фигуры:";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(91, 47);
            this.toolStripLabel4.Text = "Толщина пера:";
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.Location = new System.Drawing.Point(593, 29);
            this.trackBar1.Maximum = 12;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(130, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(729, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Заливка фигур";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(729, 49);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(102, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.черныйToolStripMenuItem,
            this.красныйToolStripMenuItem,
            this.синийToolStripMenuItem,
            this.зеленыйToolStripMenuItem,
            this.другойToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::MDIPaint.Properties.Resources._171936_paint_icon;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(30, 30);
            this.toolStripDropDownButton1.Text = "Выбор цвета";
            // 
            // черныйToolStripMenuItem
            // 
            this.черныйToolStripMenuItem.Image = global::MDIPaint.Properties.Resources.black;
            this.черныйToolStripMenuItem.Name = "черныйToolStripMenuItem";
            this.черныйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.черныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.черныйToolStripMenuItem.Text = "Черный";
            this.черныйToolStripMenuItem.Click += new System.EventHandler(this.черныйToolStripMenuItem_Click);
            // 
            // красныйToolStripMenuItem
            // 
            this.красныйToolStripMenuItem.Image = global::MDIPaint.Properties.Resources.red;
            this.красныйToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.красныйToolStripMenuItem.Name = "красныйToolStripMenuItem";
            this.красныйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.красныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.красныйToolStripMenuItem.Text = "Красный";
            this.красныйToolStripMenuItem.Click += new System.EventHandler(this.красныйToolStripMenuItem_Click);
            // 
            // синийToolStripMenuItem
            // 
            this.синийToolStripMenuItem.Image = global::MDIPaint.Properties.Resources.blue;
            this.синийToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.синийToolStripMenuItem.Name = "синийToolStripMenuItem";
            this.синийToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.синийToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.синийToolStripMenuItem.Text = "Синий";
            this.синийToolStripMenuItem.Click += new System.EventHandler(this.синийToolStripMenuItem_Click);
            // 
            // зеленыйToolStripMenuItem
            // 
            this.зеленыйToolStripMenuItem.Image = global::MDIPaint.Properties.Resources.green;
            this.зеленыйToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.зеленыйToolStripMenuItem.Name = "зеленыйToolStripMenuItem";
            this.зеленыйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.зеленыйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.зеленыйToolStripMenuItem.Text = "Зеленый";
            this.зеленыйToolStripMenuItem.Click += new System.EventHandler(this.зеленыйToolStripMenuItem_Click);
            // 
            // другойToolStripMenuItem
            // 
            this.другойToolStripMenuItem.Name = "другойToolStripMenuItem";
            this.другойToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.другойToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.другойToolStripMenuItem.Text = "Другой...";
            this.другойToolStripMenuItem.Click += new System.EventHandler(this.другойToolStripMenuItem_Click);
            // 
            // brushButton
            // 
            this.brushButton.AutoSize = false;
            this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushButton.Image = global::MDIPaint.Properties.Resources._197217_brush_meanicons_paint_art_icon;
            this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushButton.Name = "brushButton";
            this.brushButton.Size = new System.Drawing.Size(30, 30);
            this.brushButton.Text = "Кисть";
            this.brushButton.Click += new System.EventHandler(this.brushButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.AutoSize = false;
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.Image = global::MDIPaint.Properties.Resources._8673419_ic_fluent_eraser_filled_icon;
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(30, 30);
            this.eraserButton.Text = "Ластик";
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // bucketButton
            // 
            this.bucketButton.AutoSize = false;
            this.bucketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bucketButton.Image = global::MDIPaint.Properties.Resources._9025742_paint_bucket_icon;
            this.bucketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bucketButton.Name = "bucketButton";
            this.bucketButton.Size = new System.Drawing.Size(30, 30);
            this.bucketButton.Text = "Заливка";
            this.bucketButton.Click += new System.EventHandler(this.bucketButton_Click);
            // 
            // textButton
            // 
            this.textButton.AutoSize = false;
            this.textButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textButton.Image = global::MDIPaint.Properties.Resources._7968887_typography_text_tool_adobe_illustrator_tool_icon;
            this.textButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(30, 30);
            this.textButton.Text = "Текст";
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // zoomButton
            // 
            this.zoomButton.AutoSize = false;
            this.zoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomButton.Image = global::MDIPaint.Properties.Resources._2931186_greater_in_plus_zoom_explore_icon;
            this.zoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(30, 30);
            this.zoomButton.Text = "Масштаб+";
            this.zoomButton.Click += new System.EventHandler(this.zoomButton_Click);
            // 
            // nozoomButton
            // 
            this.nozoomButton.AutoSize = false;
            this.nozoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nozoomButton.Image = global::MDIPaint.Properties.Resources._2931183_minus_out_smaller_zoom_magnifier_icon;
            this.nozoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nozoomButton.Name = "nozoomButton";
            this.nozoomButton.Size = new System.Drawing.Size(30, 30);
            this.nozoomButton.Text = "Масштаб-";
            this.nozoomButton.Click += new System.EventHandler(this.nozoomButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = false;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = global::MDIPaint.Properties.Resources._352900_line_shape_icon;
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(30, 30);
            this.lineButton.Text = "Линия";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.AutoSize = false;
            this.ellipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseButton.Image = global::MDIPaint.Properties.Resources._7968868_ellipse_adobe_illustrator_tool_circle_icon;
            this.ellipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(30, 30);
            this.ellipseButton.Text = "Эллипс";
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // heartButton
            // 
            this.heartButton.AutoSize = false;
            this.heartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.heartButton.Image = global::MDIPaint.Properties.Resources._290111_favorite_heart_like_love_valentine_icon;
            this.heartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heartButton.Name = "heartButton";
            this.heartButton.Size = new System.Drawing.Size(30, 30);
            this.heartButton.Text = "Сердце";
            this.heartButton.Click += new System.EventHandler(this.heartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MDIPaint";
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерХолстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядочитьЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem красныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зеленыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другойToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton brushButton;
        private System.Windows.Forms.ToolStripButton bucketButton;
        private System.Windows.Forms.ToolStripButton textButton;
        private System.Windows.Forms.ToolStripButton zoomButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton ellipseButton;
        private System.Windows.Forms.ToolStripButton heartButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton eraserButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripButton nozoomButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem черныйToolStripMenuItem;
    }
}


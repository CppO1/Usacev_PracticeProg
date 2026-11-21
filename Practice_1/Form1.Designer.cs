namespace Practice_OOP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьФайлToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            сохранитьБДToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            dataGridViewLaps = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            dataGridViewWorkouts = new DataGridView();
            textBoxGeneralInfo = new TextBox();
            comboBoxFilter = new ComboBox();
            buttonFilter = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLaps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWorkouts).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Json|*.json";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1068, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьФайлToolStripMenuItem, выходToolStripMenuItem, сохранитьБДToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлToolStripMenuItem
            // 
            открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            открытьФайлToolStripMenuItem.Size = new Size(189, 26);
            открытьФайлToolStripMenuItem.Text = "Открыть файл";
            открытьФайлToolStripMenuItem.Click += открытьФайлToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(189, 26);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // сохранитьБДToolStripMenuItem
            // 
            сохранитьБДToolStripMenuItem.Name = "сохранитьБДToolStripMenuItem";
            сохранитьБДToolStripMenuItem.Size = new Size(189, 26);
            сохранитьБДToolStripMenuItem.Text = "Сохранить БД";
            сохранитьБДToolStripMenuItem.Click += сохранитьБДToolStripMenuItem_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.AliceBlue;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(554, 82);
            listBox1.TabIndex = 1;
            // 
            // dataGridViewLaps
            // 
            dataGridViewLaps.BackgroundColor = Color.Azure;
            dataGridViewLaps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLaps.Location = new Point(12, 175);
            dataGridViewLaps.Name = "dataGridViewLaps";
            dataGridViewLaps.RowHeadersWidth = 51;
            dataGridViewLaps.Size = new Size(554, 399);
            dataGridViewLaps.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 3;
            label1.Text = "Информация о файле";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 152);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 4;
            label2.Text = "Сводка по кругам";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Cursor = Cursors.Help;
            pictureBox1.Location = new Point(0, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1676, 682);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewWorkouts
            // 
            dataGridViewWorkouts.BackgroundColor = Color.Azure;
            dataGridViewWorkouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWorkouts.Location = new Point(587, 175);
            dataGridViewWorkouts.Name = "dataGridViewWorkouts";
            dataGridViewWorkouts.RowHeadersWidth = 51;
            dataGridViewWorkouts.Size = new Size(472, 140);
            dataGridViewWorkouts.TabIndex = 6;
            dataGridViewWorkouts.CellClick += dataGridViewWorkouts_CellClick;
            // 
            // textBoxGeneralInfo
            // 
            textBoxGeneralInfo.BackColor = Color.Azure;
            textBoxGeneralInfo.Location = new Point(587, 58);
            textBoxGeneralInfo.Multiline = true;
            textBoxGeneralInfo.Name = "textBoxGeneralInfo";
            textBoxGeneralInfo.ReadOnly = true;
            textBoxGeneralInfo.Size = new Size(472, 82);
            textBoxGeneralInfo.TabIndex = 7;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Items.AddRange(new object[] { "Все тренировки", "Круги > 5 минут", "Дистаниция > 1000 м" });
            comboBoxFilter.Location = new Point(587, 373);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(334, 28);
            comboBoxFilter.TabIndex = 8;
            comboBoxFilter.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(587, 545);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(131, 29);
            buttonFilter.TabIndex = 9;
            buttonFilter.Text = "Отфильровать";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(587, 35);
            label3.Name = "label3";
            label3.Size = new Size(276, 20);
            label3.TabIndex = 10;
            label3.Text = "Информация о выбранном  файле БД";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(587, 152);
            label4.Name = "label4";
            label4.Size = new Size(189, 20);
            label4.TabIndex = 11;
            label4.Text = "Ранее записанные файлы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(587, 338);
            label5.Name = "label5";
            label5.Size = new Size(334, 20);
            label5.TabIndex = 12;
            label5.Text = "Применить фильтрацию для главной таблицы";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 628);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonFilter);
            Controls.Add(comboBoxFilter);
            Controls.Add(textBoxGeneralInfo);
            Controls.Add(dataGridViewWorkouts);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewLaps);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Анализ скорости по кругам";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLaps).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWorkouts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьФайлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ListBox listBox1;
        private DataGridView dataGridViewLaps;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewWorkouts;
        private TextBox textBoxGeneralInfo;
        private ToolStripMenuItem сохранитьБДToolStripMenuItem;
        private ComboBox comboBoxFilter;
        private Button buttonFilter;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}

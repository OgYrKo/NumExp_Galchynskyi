namespace ForceCalculation.WinApp
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
            comboBox1 = new ComboBox();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            textBoxMod = new TextBox();
            label4 = new Label();
            buttonDefault = new Button();
            buttonDeleteAll = new Button();
            buttonCalculate = new Button();
            buttonDelete = new Button();
            textBoxZ2 = new TextBox();
            textBoxY2 = new TextBox();
            textBoxX2 = new TextBox();
            textBoxZ1 = new TextBox();
            textBoxY1 = new TextBox();
            textBoxX1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.Location = new Point(296, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 40);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 264);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(706, 532);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1545, 110);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxMod);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(buttonDefault);
            groupBox1.Controls.Add(buttonDeleteAll);
            groupBox1.Controls.Add(buttonCalculate);
            groupBox1.Controls.Add(buttonDelete);
            groupBox1.Controls.Add(textBoxZ2);
            groupBox1.Controls.Add(textBoxY2);
            groupBox1.Controls.Add(textBoxX2);
            groupBox1.Controls.Add(textBoxZ1);
            groupBox1.Controls.Add(textBoxY1);
            groupBox1.Controls.Add(textBoxX1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(762, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(771, 680);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Дії";
            // 
            // textBoxMod
            // 
            textBoxMod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxMod.Location = new Point(296, 332);
            textBoxMod.Name = "textBoxMod";
            textBoxMod.Size = new Size(98, 39);
            textBoxMod.TabIndex = 18;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(40, 332);
            label4.Name = "label4";
            label4.Size = new Size(100, 32);
            label4.TabIndex = 17;
            label4.Text = "Модуль";
            // 
            // buttonDefault
            // 
            buttonDefault.Anchor = AnchorStyles.Top;
            buttonDefault.Location = new Point(194, 501);
            buttonDefault.Name = "buttonDefault";
            buttonDefault.Size = new Size(371, 46);
            buttonDefault.TabIndex = 16;
            buttonDefault.Text = "Заповнити за замовчуванням";
            buttonDefault.UseVisualStyleBackColor = true;
            buttonDefault.Click += buttonDefault_Click;
            // 
            // buttonDeleteAll
            // 
            buttonDeleteAll.Anchor = AnchorStyles.Top;
            buttonDeleteAll.Location = new Point(457, 583);
            buttonDeleteAll.Name = "buttonDeleteAll";
            buttonDeleteAll.Size = new Size(245, 46);
            buttonDeleteAll.TabIndex = 15;
            buttonDeleteAll.Text = "Нова система сил";
            buttonDeleteAll.UseVisualStyleBackColor = true;
            buttonDeleteAll.Click += buttonDeleteAll_Click;
            // 
            // buttonCalculate
            // 
            buttonCalculate.Anchor = AnchorStyles.Top;
            buttonCalculate.Location = new Point(40, 583);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(245, 46);
            buttonCalculate.TabIndex = 14;
            buttonCalculate.Text = "Розрахувати";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top;
            buttonDelete.Location = new Point(457, 425);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(245, 46);
            buttonDelete.TabIndex = 13;
            buttonDelete.Text = "Видалити";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxZ2
            // 
            textBoxZ2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxZ2.Location = new Point(604, 240);
            textBoxZ2.Name = "textBoxZ2";
            textBoxZ2.Size = new Size(98, 39);
            textBoxZ2.TabIndex = 12;
            // 
            // textBoxY2
            // 
            textBoxY2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxY2.Location = new Point(453, 240);
            textBoxY2.Name = "textBoxY2";
            textBoxY2.Size = new Size(98, 39);
            textBoxY2.TabIndex = 11;
            // 
            // textBoxX2
            // 
            textBoxX2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxX2.Location = new Point(296, 240);
            textBoxX2.Name = "textBoxX2";
            textBoxX2.Size = new Size(98, 39);
            textBoxX2.TabIndex = 10;
            // 
            // textBoxZ1
            // 
            textBoxZ1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxZ1.Location = new Point(604, 148);
            textBoxZ1.Name = "textBoxZ1";
            textBoxZ1.Size = new Size(98, 39);
            textBoxZ1.TabIndex = 9;
            // 
            // textBoxY1
            // 
            textBoxY1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxY1.Location = new Point(453, 148);
            textBoxY1.Name = "textBoxY1";
            textBoxY1.Size = new Size(98, 39);
            textBoxY1.TabIndex = 8;
            // 
            // textBoxX1
            // 
            textBoxX1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxX1.Location = new Point(296, 148);
            textBoxX1.Name = "textBoxX1";
            textBoxX1.Size = new Size(98, 39);
            textBoxX1.TabIndex = 7;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(40, 57);
            label3.Name = "label3";
            label3.Size = new Size(79, 32);
            label3.TabIndex = 5;
            label3.Text = "Назва";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(40, 243);
            label2.Name = "label2";
            label2.Size = new Size(169, 32);
            label2.TabIndex = 4;
            label2.Text = "Кінцева точка";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(40, 155);
            label1.Name = "label1";
            label1.Size = new Size(201, 32);
            label1.TabIndex = 3;
            label1.Text = "Початкова точка";
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top;
            buttonAdd.Location = new Point(40, 425);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(245, 46);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Додати";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            ClientSize = new Size(1545, 808);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Button buttonAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxZ1;
        private TextBox textBoxY1;
        private TextBox textBoxX1;
        private TextBox textBoxZ2;
        private TextBox textBoxY2;
        private TextBox textBoxX2;
        private Button buttonDelete;
        private Button buttonCalculate;
        private Button buttonDefault;
        private Button buttonDeleteAll;
        private TextBox textBoxMod;
        private Label label4;
    }
}

namespace NE_LW_02
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            label_M1 = new Label();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            groupBox2 = new GroupBox();
            label_M2 = new Label();
            label2 = new Label();
            progressBar2 = new ProgressBar();
            button2 = new Button();
            groupBox3 = new GroupBox();
            trackBar1 = new TrackBar();
            labelT = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label_M1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1131, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Перший потік";
            // 
            // label_M1
            // 
            label_M1.AutoSize = true;
            label_M1.Location = new Point(499, 135);
            label_M1.Name = "label_M1";
            label_M1.Size = new Size(362, 32);
            label_M1.TabIndex = 3;
            label_M1.Text = "Максимальна кількість ітерацій";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 135);
            label1.Name = "label1";
            label1.Size = new Size(346, 32);
            label1.TabIndex = 2;
            label1.Text = "Статус виконання 1-го потоку";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(29, 59);
            progressBar1.Maximum = 1000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1066, 46);
            progressBar1.Step = 100;
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(945, 128);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label_M2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(progressBar2);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(12, 263);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1131, 200);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Другий потік";
            // 
            // label_M2
            // 
            label_M2.AutoSize = true;
            label_M2.Location = new Point(499, 135);
            label_M2.Name = "label_M2";
            label_M2.Size = new Size(362, 32);
            label_M2.TabIndex = 3;
            label_M2.Text = "Максимальна кількість ітерацій";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 135);
            label2.Name = "label2";
            label2.Size = new Size(346, 32);
            label2.TabIndex = 2;
            label2.Text = "Статус виконання 2-го потоку";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(29, 59);
            progressBar2.Maximum = 1000;
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(1066, 46);
            progressBar2.Step = 50;
            progressBar2.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(945, 128);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 0;
            button2.Text = "Старт";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trackBar1);
            groupBox3.Controls.Add(labelT);
            groupBox3.Location = new Point(12, 488);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1131, 200);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Основний потік";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(31, 54);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1066, 90);
            trackBar1.TabIndex = 4;
            trackBar1.TickFrequency = 5;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // labelT
            // 
            labelT.AutoSize = true;
            labelT.Location = new Point(499, 147);
            labelT.Name = "labelT";
            labelT.Size = new Size(363, 32);
            labelT.TabIndex = 3;
            labelT.Text = "Кількість ітерацій, що задається";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 250;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 729);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ProgressBar progressBar1;
        private Button button1;
        private Label label_M1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label_M2;
        private Label label2;
        private ProgressBar progressBar2;
        private Button button2;
        private GroupBox groupBox3;
        private TrackBar trackBar1;
        private Label labelT;
        private System.Windows.Forms.Timer timer1;
    }
}

namespace NE_LW_03
{
    partial class FormStream
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            labelIntegral = new Label();
            labelStatus = new Label();
            labelClock = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(labelIntegral);
            groupBox1.Controls.Add(labelStatus);
            groupBox1.Controls.Add(labelClock);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1131, 200);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Незалежний потік";
            // 
            // labelIntegral
            // 
            labelIntegral.AutoSize = true;
            labelIntegral.Location = new Point(757, 135);
            labelIntegral.Name = "labelIntegral";
            labelIntegral.Size = new Size(146, 32);
            labelIntegral.TabIndex = 4;
            labelIntegral.Text = "Інтеграл = ?";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(499, 135);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(149, 32);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "Виконано %";
            // 
            // labelClock
            // 
            labelClock.AutoSize = true;
            labelClock.Location = new Point(31, 135);
            labelClock.Name = "labelClock";
            labelClock.Size = new Size(338, 32);
            labelClock.TabIndex = 2;
            labelClock.Text = "Тривалість обчислень (сек) =";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(31, 57);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1044, 46);
            progressBar1.TabIndex = 5;
            // 
            // FormStream
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 221);
            Controls.Add(groupBox1);
            Name = "FormStream";
            Text = "FormStream";
            FormClosing += FormStream_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelStatus;
        private Label labelClock;
        private Label labelIntegral;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
    }
}
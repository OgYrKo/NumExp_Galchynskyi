namespace NE_CT_05
{
  partial class Form_MJacoby
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MJacoby));
      this.lbl_clock = new System.Windows.Forms.Label();
      this.lbl_status = new System.Windows.Forms.Label();
      this.lbl_Tc = new System.Windows.Forms.Label();
      this.gBox_task = new System.Windows.Forms.GroupBox();
      this.pBar = new System.Windows.Forms.ProgressBar();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.gBox_params = new System.Windows.Forms.GroupBox();
      this.tBox_params = new System.Windows.Forms.TextBox();
      this.lbl_iters = new System.Windows.Forms.Label();
      this.gBox_task.SuspendLayout();
      this.gBox_params.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbl_clock
      // 
      this.lbl_clock.AutoSize = true;
      this.lbl_clock.ForeColor = System.Drawing.Color.Blue;
      this.lbl_clock.Location = new System.Drawing.Point(22, 180);
      this.lbl_clock.Name = "lbl_clock";
      this.lbl_clock.Size = new System.Drawing.Size(195, 13);
      this.lbl_clock.TabIndex = 14;
      this.lbl_clock.Text = "Тривалість обчислень (сек) =   ";
      // 
      // lbl_status
      // 
      this.lbl_status.AutoSize = true;
      this.lbl_status.ForeColor = System.Drawing.Color.MediumVioletRed;
      this.lbl_status.Location = new System.Drawing.Point(22, 206);
      this.lbl_status.Name = "lbl_status";
      this.lbl_status.Size = new System.Drawing.Size(85, 13);
      this.lbl_status.TabIndex = 13;
      this.lbl_status.Text = "Виконано   %";
      // 
      // lbl_Tc
      // 
      this.lbl_Tc.AutoSize = true;
      this.lbl_Tc.ForeColor = System.Drawing.Color.DarkGreen;
      this.lbl_Tc.Location = new System.Drawing.Point(298, 180);
      this.lbl_Tc.Name = "lbl_Tc";
      this.lbl_Tc.Size = new System.Drawing.Size(107, 13);
      this.lbl_Tc.TabIndex = 12;
      this.lbl_Tc.Text = "Температура = ?";
      // 
      // gBox_task
      // 
      this.gBox_task.Controls.Add(this.pBar);
      this.gBox_task.Location = new System.Drawing.Point(12, 119);
      this.gBox_task.Name = "gBox_task";
      this.gBox_task.Size = new System.Drawing.Size(626, 53);
      this.gBox_task.TabIndex = 11;
      this.gBox_task.TabStop = false;
      this.gBox_task.Text = "  Процес виконання завдання  ";
      // 
      // pBar
      // 
      this.pBar.BackColor = System.Drawing.Color.White;
      this.pBar.ForeColor = System.Drawing.Color.LimeGreen;
      this.pBar.Location = new System.Drawing.Point(13, 26);
      this.pBar.Name = "pBar";
      this.pBar.Size = new System.Drawing.Size(602, 8);
      this.pBar.Step = 1;
      this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.pBar.TabIndex = 0;
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // gBox_params
      // 
      this.gBox_params.Controls.Add(this.tBox_params);
      this.gBox_params.Location = new System.Drawing.Point(12, 7);
      this.gBox_params.Name = "gBox_params";
      this.gBox_params.Size = new System.Drawing.Size(626, 106);
      this.gBox_params.TabIndex = 15;
      this.gBox_params.TabStop = false;
      this.gBox_params.Text = "  Параметри завдання  ";
      // 
      // tBox_params
      // 
      this.tBox_params.BackColor = System.Drawing.SystemColors.Info;
      this.tBox_params.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tBox_params.Location = new System.Drawing.Point(59, 18);
      this.tBox_params.Multiline = true;
      this.tBox_params.Name = "tBox_params";
      this.tBox_params.ReadOnly = true;
      this.tBox_params.Size = new System.Drawing.Size(557, 81);
      this.tBox_params.TabIndex = 10;
      this.tBox_params.TabStop = false;
      this.tBox_params.Text = "My_NumExp";
      // 
      // lbl_iters
      // 
      this.lbl_iters.AutoSize = true;
      this.lbl_iters.ForeColor = System.Drawing.Color.Indigo;
      this.lbl_iters.Location = new System.Drawing.Point(170, 206);
      this.lbl_iters.Name = "lbl_iters";
      this.lbl_iters.Size = new System.Drawing.Size(115, 13);
      this.lbl_iters.TabIndex = 16;
      this.lbl_iters.Text = "Виконано ітерацій";
      // 
      // Form_MJacoby
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(645, 228);
      this.Controls.Add(this.lbl_iters);
      this.Controls.Add(this.gBox_params);
      this.Controls.Add(this.lbl_clock);
      this.Controls.Add(this.lbl_status);
      this.Controls.Add(this.lbl_Tc);
      this.Controls.Add(this.gBox_task);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form_MJacoby";
      this.Text = "  Form_MJacoby";
      this.gBox_task.ResumeLayout(false);
      this.gBox_params.ResumeLayout(false);
      this.gBox_params.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbl_clock;
    private System.Windows.Forms.Label lbl_status;
    private System.Windows.Forms.Label lbl_Tc;
    private System.Windows.Forms.GroupBox gBox_task;
    private System.Windows.Forms.ProgressBar pBar;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.GroupBox gBox_params;
    private System.Windows.Forms.Label lbl_iters;
    private System.Windows.Forms.TextBox tBox_params;
  }
}
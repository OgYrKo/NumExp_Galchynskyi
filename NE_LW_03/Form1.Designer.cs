namespace NE_LW_03
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
            numericUpDownN = new NumericUpDown();
            numericUpDownBetta = new NumericUpDown();
            numericUpDownAlpha = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            kColumn = new DataGridViewTextBoxColumn();
            aColumn = new DataGridViewTextBoxColumn();
            bColumn = new DataGridViewTextBoxColumn();
            nColumn = new DataGridViewTextBoxColumn();
            IntegralColumn = new DataGridViewTextBoxColumn();
            TimeColumn = new DataGridViewTextBoxColumn();
            buttonCalc = new Button();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBetta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAlpha).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownN);
            groupBox1.Controls.Add(numericUpDownBetta);
            groupBox1.Controls.Add(numericUpDownAlpha);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(29, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(854, 121);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметри обчислень";
            // 
            // numericUpDownN
            // 
            numericUpDownN.Location = new Point(627, 57);
            numericUpDownN.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownN.Name = "numericUpDownN";
            numericUpDownN.Size = new Size(111, 39);
            numericUpDownN.TabIndex = 5;
            numericUpDownN.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownBetta
            // 
            numericUpDownBetta.DecimalPlaces = 2;
            numericUpDownBetta.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownBetta.Location = new Point(418, 57);
            numericUpDownBetta.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownBetta.Minimum = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDownBetta.Name = "numericUpDownBetta";
            numericUpDownBetta.Size = new Size(111, 39);
            numericUpDownBetta.TabIndex = 4;
            numericUpDownBetta.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // numericUpDownAlpha
            // 
            numericUpDownAlpha.DecimalPlaces = 2;
            numericUpDownAlpha.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownAlpha.Location = new Point(152, 55);
            numericUpDownAlpha.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownAlpha.Minimum = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDownAlpha.Name = "numericUpDownAlpha";
            numericUpDownAlpha.Size = new Size(111, 39);
            numericUpDownAlpha.TabIndex = 3;
            numericUpDownAlpha.Value = new decimal(new int[] { 70, 0, 0, 131072 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(570, 57);
            label3.Name = "label3";
            label3.Size = new Size(51, 32);
            label3.TabIndex = 2;
            label3.Text = "n =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 57);
            label2.Name = "label2";
            label2.Size = new Size(99, 32);
            label2.TabIndex = 1;
            label2.Text = "betta = ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 55);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 0;
            label1.Text = "alpha = ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(29, 198);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1133, 360);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Результати";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { kColumn, aColumn, bColumn, nColumn, IntegralColumn, TimeColumn });
            dataGridView.Location = new Point(44, 54);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(1034, 300);
            dataGridView.TabIndex = 0;
            // 
            // kColumn
            // 
            kColumn.HeaderText = "k";
            kColumn.MinimumWidth = 10;
            kColumn.Name = "kColumn";
            kColumn.ReadOnly = true;
            kColumn.Width = 50;
            // 
            // aColumn
            // 
            aColumn.HeaderText = "alpha";
            aColumn.MinimumWidth = 10;
            aColumn.Name = "aColumn";
            aColumn.ReadOnly = true;
            aColumn.Width = 200;
            // 
            // bColumn
            // 
            bColumn.HeaderText = "betta";
            bColumn.MinimumWidth = 10;
            bColumn.Name = "bColumn";
            bColumn.ReadOnly = true;
            bColumn.Width = 200;
            // 
            // nColumn
            // 
            nColumn.HeaderText = "n";
            nColumn.MinimumWidth = 10;
            nColumn.Name = "nColumn";
            nColumn.ReadOnly = true;
            nColumn.Width = 50;
            // 
            // IntegralColumn
            // 
            IntegralColumn.HeaderText = "Інтеграл";
            IntegralColumn.MinimumWidth = 10;
            IntegralColumn.Name = "IntegralColumn";
            IntegralColumn.ReadOnly = true;
            IntegralColumn.Width = 300;
            // 
            // TimeColumn
            // 
            TimeColumn.HeaderText = "Час виконання";
            TimeColumn.MinimumWidth = 10;
            TimeColumn.Name = "TimeColumn";
            TimeColumn.ReadOnly = true;
            TimeColumn.Width = 150;
            // 
            // buttonCalc
            // 
            buttonCalc.Location = new Point(951, 126);
            buttonCalc.Name = "buttonCalc";
            buttonCalc.Size = new Size(211, 46);
            buttonCalc.TabIndex = 2;
            buttonCalc.Text = "Обчислити";
            buttonCalc.UseVisualStyleBackColor = true;
            buttonCalc.Click += buttonCalc_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 620);
            Controls.Add(buttonCalc);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBetta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAlpha).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numericUpDownN;
        private NumericUpDown numericUpDownBetta;
        private NumericUpDown numericUpDownAlpha;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private Button buttonCalc;
        private DataGridViewTextBoxColumn kColumn;
        private DataGridViewTextBoxColumn aColumn;
        private DataGridViewTextBoxColumn bColumn;
        private DataGridViewTextBoxColumn nColumn;
        private DataGridViewTextBoxColumn IntegralColumn;
        private DataGridViewTextBoxColumn TimeColumn;
        private ErrorProvider errorProvider1;
    }
}

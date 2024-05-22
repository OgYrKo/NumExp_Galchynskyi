using System.Collections.Generic;

namespace NE_LW_03
{
    public partial class Form1 : Form
    {
        public double Betta
        {
            get => (double)numericUpDownBetta.Value;
            set => numericUpDownBetta.Value = (decimal)value;
        }
        public double Alpha
        {
            get => (double)numericUpDownAlpha.Value;
            set => numericUpDownAlpha.Value = (decimal)value;
        }
        public int N
        {
            get => (int)numericUpDownN.Value;
            set => numericUpDownN.Value = value;
        }

        List<FormStream> StreamList;
        public Form1()
        {
            InitializeComponent();
            StreamList = new List<FormStream>();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            int k = StreamList.Count;
            StreamList.Add(new FormStream(this,k,N,Alpha,Betta));
            StreamList[k].StartPosition = FormStartPosition.Manual;
            StreamList[k].Location = new Point(Location.X + 50 + k * 30, Location.Y + 275 + k * 30);
            StreamList[k].Show();
            StreamList[k].StartStream();
        }

        public void UpdateResult(int k, double alpha, double betta, int n, double Integral, decimal time)
        {
            var index = dataGridView.Rows.Add();
            dataGridView.Rows[index].Cells["kColumn"].Value = k;
            dataGridView.Rows[index].Cells["aColumn"].Value = alpha;
            dataGridView.Rows[index].Cells["bColumn"].Value = betta;
            dataGridView.Rows[index].Cells["nColumn"].Value = n;
            dataGridView.Rows[index].Cells["IntegralColumn"].Value = Integral;
            dataGridView.Rows[index].Cells["TimeColumn"].Value = $"{time} sec";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (FormStream stream in StreamList)
            {
                stream.Close();
            }
        }
    }
}

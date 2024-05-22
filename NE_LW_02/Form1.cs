namespace NE_LW_02
{
    public partial class Form1 : Form
    {
        Thread? stream_1, stream_2;
        int status_1, status_2;
        int Max_1 
        { 
            get => progressBar1.Maximum; 
            set => progressBar1.Maximum = value; 
        }
        int Max_2
        {
            get => progressBar2.Maximum; 
            set => progressBar2.Maximum = value; 
        }
        int Step_1
        {
            get => progressBar1.Step; 
            set => progressBar1.Step = value; 
        }
        int Step_2
        {
            get => progressBar2.Step; 
            set => progressBar2.Step = value; 
        }
        public Form1()
        {
            InitializeComponent();
        }
        void STREAM_1()
        {
            status_1 = 0;
            for (int i = 0; i <= Max_1; i += Step_1)
            {
                status_1 = i;
                Thread.Sleep(Step_1);
            }
        }

        void STREAM_2()
        {
            status_2 = 0;
            for (int i = 0; i <= Max_2; i += Step_2)
            {
                status_2 = i;
                Thread.Sleep(Step_2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Max_1 = trackBar1.Value * Step_1; 
            label_M1.Text = $"Max = {Max_1}";
            stream_1 = new Thread(STREAM_1); stream_1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Max_2 = trackBar1.Value * Step_2; 
            label_M2.Text = $"Max = {Max_2}";
            stream_2 = new Thread(STREAM_2); stream_2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stream_1 != null)
            {
                progressBar1.Value = status_1;
                label1.Text = $"Status 1 = {status_1}";
                if (!stream_1.IsAlive)
                {
                    button1.Enabled = true;
                    stream_1 = null;
                }
            }
            if (stream_2 != null)
            {
                progressBar2.Value = status_2;
                label2.Text = $"Status 2 = {status_2}";
                if (!stream_2.IsAlive)
                {
                    button2.Enabled = true;
                    stream_2 = null;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelT.Text = $"Кількість ітерацій = {trackBar1.Value}";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stream_1 != null && stream_1.IsAlive)
            {
                stream_1.Abort();
                stream_1 = null;
            }
            if (stream_2 != null && stream_2.IsAlive)
            {
                stream_2.Abort();
                stream_2 = null;
            }
        }
    }
}

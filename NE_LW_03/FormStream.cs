using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using CBF = NE_DLL.NE_Bessel_Functions;
using CGQ = NE_DLL.MAC_Gauss_Quadrature;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NE_DLL;

namespace NE_LW_03
{
    public partial class FormStream : Form
    {
        private double _alpha, _betta, Integral;
        private int _k, _n;
        private Thread? _stream;
        private Stopwatch _clock;
        private CGQ _gauss;
        private Form1 _main;
        public FormStream(Form1 main,int k, int n, double alpha, double betta)
        {
            InitializeComponent();
            _k = k;
            _n = n;
            _alpha = alpha;
            _betta = betta;
            _main = main;
            this.Text = $" {_k}-й потік ";
            groupBox1.Text = $" alpha = {_alpha,4:F2}  betta = {_betta,4:F2}  n = {_n}";
        }

        public void StartStream()
        {
            _stream = new Thread(INTEGRAL);
            _stream.Start();
            timer1.Enabled = true;
        }

        private void INTEGRAL()
        {
            _clock = new Stopwatch();
            _clock.Start();
            _gauss = new CGQ(32);
            Integral = _gauss.Improper(0.0, AB_11_4_36, 1.0E-7, out double B);
            _clock.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal time = _clock.ElapsedMilliseconds / 1000;
            int status = (int)_gauss.status;
            if (status > 100) status = 100;
            if (!_stream!.IsAlive)
            {
                _main.UpdateResult(_k, _alpha, _betta, _n, Integral, time);
                labelIntegral.Text = string.Format("Інтеграл = {0:F14}", Integral);
                timer1.Enabled = false;
                _stream = null;
            }
            progressBar1.Value = status;
            labelStatus.Text = string.Format("Виконано = {0}%", status);
            labelClock.Text = string.Format("Тривалість обчислень = {0} сек", time);
            Refresh();
        }


        double AB_11_4_36(double t) => CBF.Jn(_n, _alpha * t) * Math.Cos(_betta * t) / t;

        private void FormStream_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_stream != null && _stream.IsAlive)
            {
                _stream.Abort();
            }
        }
    }
}

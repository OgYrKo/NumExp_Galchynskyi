using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using RP = NE_DLL.NE_Rectangular_Plate;
using System.IO;

namespace NE_CT_05
{
  public partial class Form_MJacoby : Form
  {
    double T1, T2, T3, T4, a, b, xc, yc, eps, Tc, Td, err;
    int k1, k2, k3, k4, m, k, iters, ic, jc; decimal status; string title;
    Stopwatch clock;

    public Thread task = null;

    public Form_MJacoby()
    {
      InitializeComponent(); k = Main_Form_CT_5.k;
      T1 = Main_Form_CT_5.T1; k1 = Main_Form_CT_5.k1;
      T2 = Main_Form_CT_5.T2; k2 = Main_Form_CT_5.k2;
      T3 = Main_Form_CT_5.T3; k3 = Main_Form_CT_5.k3;
      T4 = Main_Form_CT_5.T4; k4 = Main_Form_CT_5.k4;
      a = Main_Form_CT_5.a; xc = Main_Form_CT_5.xc;
      b = Main_Form_CT_5.b; yc = Main_Form_CT_5.yc;
      m = Main_Form_CT_5.m; eps = Main_Form_CT_5.eps;
      title = Main_Form_CT_5.title;

      RP plate = new RP(a, b, T1, T2, T3, T4, k1, k2, k3, k4);
      Tc = plate.Txy(xc, yc);

      string txt = "";
      txt += $" T1 ={T1,5:F1}  k1 = {k1,1:F0}    a ={a,4:F1}       xc ={xc,4:F1}\r\n";
      txt += $" T2 ={T2,5:F1}  k2 = {k2,1:F0}    b ={b,4:F1}       yc ={yc,4:F1}\r\n";
      txt += $" T3 ={T3,5:F1}  k3 = {k3,1:F0}    m = {m}\r\n";
      txt += $" T4 ={T4,5:F1}  k4 = {k4,1:F0}  eps ={eps,8:F5}   Tc = {Tc,7:F4}\r\n";

      tBox_params.Text = txt; Text = "   " + title;
      gBox_params.Text += $" k = {k}";
      timer1.Enabled = true; pBar.Focus();
    }

    public void StartTask()
    {
      task = new Thread(MJacoby); task.Start();
    }

    void MJacoby()
    {
      clock = new Stopwatch(); clock.Start();

      // Індексні координати датчика
      ic = (int)(xc * m); jc = (int)(yc * m);

      // Різницева сітка
      int M = (int)(a * m), N = (int)(b * m);
      (double t0, double t1)[,] T = new (double, double)[M + 1, N + 1];
      double[,] E = new double[M + 1, N + 1];


      int i, j, steps = 0; iters = 0;
      // Ініціалізація "початкового" поля теператур відповідними значеннями
      for (i = 1; i < M; i++)
        for (j = 1; j < N; j++) { T[i, j] = (0.0, 0.0); E[i, j] = 1.0; }

      double h = 1.0 / m, x = 0.0, y = 0.0, t;
      // Граничні умови на ребрах (1) і (2)
      double al_1 = Math.PI * k1 / a; double al_2 = Math.PI * k2 / a;
      double bt_3 = Math.PI * k3 / b; double bt_4 = Math.PI * k4 / b;
      for (i = 0; i <= M; i++)
      {
        x = i * h;
        t = T1 * Math.Sin(al_1 * x); T[i, 0] = (t, t);
        t = T2 * Math.Sin(al_2 * x); T[i, N] = (t, t);
      }
      // Граничні умови на ребрах (3) і (4)
      for (j = 0; j <= N; j++)
      {
        y = j * h;
        t = T3 * Math.Sin(bt_3 * y); T[0, j] = (t, t);
        t = T4 * Math.Sin(bt_4 * y); T[M, j] = (t, t);
      }

      // Ітерації за схемою Якобі
      err = (Math.Abs(T1) + Math.Abs(T2) + Math.Abs(T3) + Math.Abs(T4)) / 4;
      do
      {
        iters++; steps++;
        for (i = 1; i < M; i++)
          for (j = 1; j < N; j++)
            T[i, j].t1 = (T[i - 1, j].t0 + T[i + 1, j].t0 + T[i, j - 1].t0 + T[i, j + 1].t0) / 4;

        for (i = 1; i < M; i++)
          for (j = 1; j < N; j++)
            T[i, j].t0 = (T[i - 1, j].t1 + T[i + 1, j].t1 + T[i, j - 1].t1 + T[i, j + 1].t1) / 4;

        Td = T[ic, jc].t0;

        // Перевірка процесу збіжності методу та обчислення похибки ітерацій
        if (steps == m)
        {
          err = double.MinValue;
          for (i = 1; i < M; i++)
            for (j = 1; j < N; j++)
            {
              t = Math.Abs(E[i, j] - T[i, j].t0); E[i, j] = T[i, j].t0; err = Math.Max(err, t);
            }

          status = (decimal)(100 * Math.Abs(eps) / Math.Abs(err)); steps = 0;
          if (status > 100) status = 100;
        }
      }
      while (Math.Abs(err) > eps);

      clock.Stop();

      // Виведення результатів чисельного експеримента в файл для подальшої обробки в Surfer
      StreamWriter surfer = new StreamWriter($"{title}.txt");
      for (j = 0; j <= N; j++)
      {
        y = h * j;
        for (i = 0; i <= M; i++)
        {
          x = h * i;
          surfer.WriteLine($" {x,10:F6}  {y,10:F6}  {T[i, j].t0,12:F8}".Replace(',', '.'));
        }
      }
      surfer.Close();
    }

    void timer1_Tick(object sender, EventArgs e)
    {
      decimal time = clock.ElapsedMilliseconds / 1000;
      pBar.Value = (int)status;
      lbl_status.Text = $"Виконано {status,5:F1} %";
      lbl_clock.Text = $"Тривалість обчислень {clock.ElapsedMilliseconds / 1000} сек";
      lbl_Tc.Text = $"Температура в датчику T[{ic},{jc}] = {Td,8:F4}";
      lbl_iters.Text = $"Виконано ітерацій = {iters}       Поточна похибка = {err,8:F5} ";
      if (!task.IsAlive)
      {
        int calc = (int)clock.ElapsedMilliseconds / 1000;
        Main_Form_CT_5.Result += $"{title}{Td,12:F4}{iters,16}{err,15:F5}{calc,12}\r\n";
        task = null; timer1.Enabled = false;
      }
      Refresh();
    }
  }
}

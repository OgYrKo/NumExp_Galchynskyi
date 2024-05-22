using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using RP = NE_DLL.NE_Rectangular_Plate;

namespace NE_DLL
{
  public class NE_Method_Jacoby
  {
    public decimal status;
    public void Rect_Plate(double T1, double T2, double T3, double T4,
                           double a, double b, double xc, double yc,
                           int k1, int k2, int k3, int k4, int m,
                           double eps, string title)
    {
      // Індексні координати датчика
      int ic = (int)(xc * m), jc = (int)(yc * m);

      // Екземплар відповідного точного розв'язку
      RP plate = new RP(a, b, T1, T2, T3, T4, k1, k2, k3, k4);
      double Tc = plate.Txy(xc, yc);

      // Різницева сітка
      int M = (int)(a * m), N = (int)(b * m);

      (double t0, double t1)[,] T = new (double, double)[M + 1, N + 1];

      int i, j, iters = 0, steps = 0;
      // Ініціалізація "початкового" поля теператур відповідними значеннями
      for (i = 1; i < M; i++)
        for (j = 1; j < N; j++) T[i, j] = (0.0, 0.0);

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
      Stopwatch clock = new Stopwatch(); clock.Start();
      double err1 = 0.0, err = double.MaxValue,
             err2 = (Math.Abs(T1) + Math.Abs(T2) + Math.Abs(T3) + Math.Abs(T4)) / 4;
      do
      {
        iters++; steps++;
        for (i = 1; i < M; i++)
          for (j = 1; j < N; j++)
            T[i, j].t1 = (T[i - 1, j].t0 + T[i + 1, j].t0 + T[i, j - 1].t0 + T[i, j + 1].t0) / 4;

        for (i = 1; i < M; i++)
          for (j = 1; j < N; j++)
            T[i, j].t0 = (T[i - 1, j].t1 + T[i + 1, j].t1 + T[i, j - 1].t1 + T[i, j + 1].t1) / 4;
               

        // Перевірка процесу збіжності методу та обчислення похибки ітерацій
        if (steps == m)
        {
          err1 = err2; err2 = T[ic, jc].t0; err = err2 - err1; steps = 0;
          status = (decimal)(100 * Math.Abs(eps) / Math.Abs(err));
          if (status > 100) status = 100;
          Console.WriteLine($" {iters,8}    T[{ic,6},{jc,6}] = {err2,12:F8}  {err,12:F8}  {status,5:F2}%");
        }

      }
      while (Math.Abs(err) > eps);

      clock.Stop();
      Console.WriteLine($" iters = {iters}  error = {err,8:E1}  time = {clock.ElapsedMilliseconds / 1000} sec");
      Console.WriteLine($" T[{ic},{jc}] = {T[ic, jc].t0,12:F8}");
      Console.WriteLine($" {xc,10:F6}  {yc,10:F6}   {plate.Txy(xc, yc),12:F8}");

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
  }
}


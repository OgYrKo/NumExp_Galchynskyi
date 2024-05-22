using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_DLL
{
    public abstract class MAC_Integration
    {
        protected int n;                     // порядок квадратурної формули 
        protected double[] X, W;             // абсциси та вагові коефіцієнти
        protected Func<double, double> fx;   // підінтегральна функція

        protected abstract void Abscises_and_Weights();          // X[] i W[]
        protected abstract double Scheme(double aj, double bj);  //  (5.3.0)
        protected int m, iter;
        public decimal status;

        //-- Ітераційне обчислення визначеного інтеграла із заданою похибкою eps --//
        public double Integral(double a, double b, Func<double, double> f, double eps)
        {
            double hm, I0 = 0.0, I1 = double.MaxValue;
            m = (int)(b - a) + 1; iter = 0; fx = f;
            while (Math.Abs(I1 - I0) > eps)
            {
                iter++; if (iter > 1) m *= 2; I0 = I1; I1 = 0.0; hm = (b - a) / m;
                for (int j = 1; j <= m; j++) I1 += Scheme(a + (j - 1) * hm, b - (m - j) * hm);
            }
            return I1;
        }

        //-- Ітераційне обчислення невласного інтеграла із заданою похибкою eps --//
        public double Improper(double a, Func<double, double> f, double eps, out double b)
        {
            double hi = 50.0, ai = a, bi = a + hi, improper, imp;

            improper = Integral(ai, bi, f, eps); // нульове наближення до шуканого значення
            do
            {
                hi = (bi - a) / 10;
                ai = bi; bi += hi;
                imp = Integral(ai, bi, f, eps); improper += imp;
                Console.WriteLine($" < {ai,13:F1}  {bi,13:F1} >   {imp,20:F16}");
                status = (decimal)(100 * Math.Log10(Math.Abs(imp)) / Math.Log10(eps));
            }
            while (Math.Abs(imp) > eps);
            b = bi;
            return improper;
        }

        //-- Друк додаткової інформації за даною квадратурною схемою --//
        public virtual string ToPrint(string comment) => comment;
    }

    // Клас, який реалізує інтегрування за схемою Ньютона-Котеса заданого порядку n
    public class MAC_Cotes_Quadrature : MAC_Integration
    {
        //-- Конструктор --//
        public MAC_Cotes_Quadrature(int n)
        {
            if ((n < 2) || (n > 18)) this.n = 2; else this.n = n;
            Abscises_and_Weights();
        }

        //-- Обчислення абсцис та вагових коефіцієнтів Котеса --//
        protected override void Abscises_and_Weights()
        {
            int i, j, k; decimal rni;
            decimal[] A = new decimal[n + 1];
            decimal[] H = new decimal[n + 1];
            long[] a = new long[n + 1];
            W = new double[n + 1]; X = new double[n + 1];

            for (i = 0; i <= n; i++)
            {
                a[0] = 1; for (j = 1; j <= n; j++) a[j] = 0;

                for (k = 0; k <= n; k++)
                {
                    if (k == i) continue;
                    for (j = n; j >= 1; j--) a[j] = a[j - 1] - k * a[j];
                    a[0] = -k * a[0];
                }
                rni = 1;
                for (j = 1; j <= i; j++) rni /= j;
                for (j = 1; j <= (n - i); j++) rni /= -j;
                for (j = 0; j <= n; j++) A[j] = rni * a[j];

                rni = 1;
                for (j = 0; j <= n; j++)
                { H[i] = H[i] + A[j] * (rni / (j + 1)); rni *= n; }
                W[i] = Convert.ToDouble(H[i]); X[i] = i * (1.0 / n);
            }
        }

        //-- Квадратурна Схема Ньютона-Котеса --//
        protected override double Scheme(double aj, double bj)
        {
            double integral_j = 0.0, hj = bj - aj;
            for (int i = 0; i <= n; i++) integral_j += W[i] * fx(aj + X[i] * hj);
            return hj * integral_j;
        }

        public override string ToPrint(string comment)
        {
            string print = $"\r\n    MAC_Cotes_Quadrature: {comment} ";
            print += $"  n = {n}   m = {m}  iter = {iter}\r\n\r\n";
            for (int i = 0; i <= n; i++)
                print += $" X[{n,2},{i,2}] ={X[i],24:E15}  W[{n,2},{i,2}] ={W[i],24:E15}\r\n";
            return print;
        }
    }

    // Клас, який реалізує інтегрування за схемою Гаусса заданого порядку n
    public class MAC_Gauss_Quadrature : MAC_Integration
    {
        //-- Конструктор --//
        public MAC_Gauss_Quadrature(int N)
        {
            if ((N < 2) || (N > 48)) n = 2; else n = N;
            Abscises_and_Weights();
        }

        //-- Обчислення абсцис та вагових коефіцієнтів Гаусса --//
        protected override void Abscises_and_Weights()
        {
            int i, j, m, k;
            double hx, x_a, x_b, x_c, x_old, fx_a, fx_b, fx_c, pl;
            X = new double[n + 1]; W = new double[n + 1];

            k = n / 2; m = n - k;
            if (m != k) { X[m] = 0.0; pl = n * PL(n - 1, X[m]); W[m] = 2.0 / pl / pl; }

            hx = 0.1 / k; x_b = hx; x_old = 0.0;
            for (i = 1; i <= k; i++)
            {
                x_a = x_b; fx_a = PL(n, x_a);
                do
                {
                    x_b += hx; fx_b = PL(n, x_b);
                }
                while (fx_a * fx_b > 0);

                j = 0; x_a = x_b - hx;
                do
                {
                    x_c = x_a + (x_b - x_a) * 0.5; j += 1;
                    fx_c = PL(n, x_c);
                    if ((fx_a * fx_c) < 0) x_b = x_c; else x_a = x_c;
                }
                while ((Math.Abs(fx_c) > 0.5E-15) && (j < 65));

                X[m + i] = x_c; pl = n * PL(n - 1, x_c);
                W[m + i] = 2.0 * (1.0 - x_c * x_c) / pl / pl;

                X[k - i + 1] = -x_c; W[k - i + 1] = W[m + i];
                hx = (x_c - x_old) / 3; x_old = x_c;
            }
        }

        //-- Квадратурна Схема Гаусса --//
        protected override double Scheme(double a, double b)
        {
            double B = (b + a) / 2.0, A = (b - a) / 2.0, integral_j = 0.0;
            for (int i = 1; i <= n; i++) integral_j += W[i] * fx(A * X[i] + B);
            return A * integral_j;
        }

        public override string ToPrint(string comment)
        {
            string print = $"\r\n    MAC_Gauss_Quadrature: {comment} ";
            print += $"  n = {n}   m = {m}  iter = {iter}\r\n\r\n";
            for (int i = 1; i <= n; i++)
                print += $" X[{n,2},{i,2}] ={X[i],24:E15}  W[{n,2},{i,2}] ={W[i],24:E15}\r\n";
            return print;
        }

        static double PL(int n, double x)
        {
            if (n == 0) return 1.0; if (n == 1) return x;

            double pn_1 = x, pn_2 = 1.0, pn = double.NaN, an;

            for (int j = 2; j <= n; j++)
            {
                an = 1.0 - 1.0 / j;
                pn = (1.0 + an) * x * pn_1 - an * pn_2;
                pn_2 = pn_1; pn_1 = pn;
            }
            return pn;
        }
    }
}

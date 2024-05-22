using System.Diagnostics;
using CBF = NE_DLL.NE_Bessel_Functions;
using CGQ = NE_DLL.MAC_Gauss_Quadrature;
namespace NE_LW_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
        }

        static void Test(Func<int, double, double> foo, string filename)
        {
            const int n0 = 0, n1 = 1, n2 = 2;
            double x = 0.0, hx = 2.0, J0, J1, J2, error;

            using (StreamWriter SW = new StreamWriter(filename))
            {
                SW.WriteLine($"x             J0(x)                 J1(x)" +
                             $"                 J2(x)            error");
                while (x < 50.5)
                {
                    J0 = foo(n0, x);
                    J1 = foo(n1, x);
                    J2 = foo(n2, x);
                    error = J1 - 0.5 * x * (J2 + J0);
                    SW.WriteLine($" {x,4:F1}{J0,22:F16}{J1,22:F16}{J2,22:F16}{error,12:E1}");
                    x += hx;
                }
            }
        }
        static void Test1() => Test(CBF.BF_J_test1, "Test_1.txt");
        static void Test2() => Test(CBF.BF_J_test2, "Test_2.txt");
        static void Test3() => Test(CBF.BF_J_test3, "Test_3.txt");
        static void Test4()
        {
            double alpha, betta, appr_value, true_value, error,B;
            int n, m;
            string title;

            CGQ gauss = new CGQ(32);
            Stopwatch clock = new Stopwatch();
            clock.Start();

            title = "DW_856_31"; alpha = 0.7; betta = 0.5; // alpha > betta 
            appr_value = gauss.Improper(0.0, DW_856_31, 1.0E-13, out B);
            true_value = 0.5 * Math.PI / alpha / betta / (alpha + betta);
            error = Math.Abs(true_value - appr_value);
            clock.Stop();
            WriteToFIle("Test_4.txt", title, clock.ElapsedMilliseconds, appr_value, true_value, B, error);
            clock.Start();

            title = "DW_858_711"; n = 3; m = 2; // n > m
            appr_value = gauss.Improper(0.0, DW_858_711, 1.0E-13, out B);
            true_value = 0.5 * Math.PI * m;
            error = Math.Abs(true_value - appr_value);
            clock.Stop();
            WriteToFIle("Test_4.txt", title, clock.ElapsedMilliseconds, appr_value, true_value, B, error, true);
            clock.Start();

            title = "DW_859_005"; m = 2; alpha = 1.7;
            appr_value = gauss.Improper(0.0, DW_859_005, 1.0E-13, out B);
            true_value = Math.PI / 2 / alpha / alpha * (1.0 - Math.Exp(-m * alpha));
            error = Math.Abs(true_value - appr_value);

            clock.Stop();
            WriteToFIle("Test_4.txt", title, clock.ElapsedMilliseconds, appr_value, true_value, B, error, true);

            double DW_856_31(double x) => 1.0 / (alpha * alpha + x * x) / (betta * betta + x * x);
            double DW_858_711(double x) => (Math.Sin(m * x) / x) * (Math.Sin(n * x) / x);
            double DW_859_005(double x) => Math.Sin(m * x) / (alpha * alpha + x * x) / x;
        }
        static void Test5()
        {
            double alpha = 0.7, betta = 0.5, appr_value, true_value, error;
            int n = 1;
            string title = "AB_11_4_36";

            // alpha > betta   n > 0    !

            CGQ gauss = new CGQ(32); Stopwatch clock = new Stopwatch(); clock.Start();

            appr_value = gauss.Improper(0.0, AB_11_4_36, 1.0E-8, out double B);
            True_Value(); error = Math.Abs(true_value - appr_value); clock.Stop();
            WriteToFIle("Test_5.txt", title, clock.ElapsedMilliseconds, appr_value, true_value, B, error);

            double AB_11_4_36(double t) => CBF.Jn(n, alpha * t) * Math.Cos(betta * t) / t;
            void True_Value()
            {
                if (alpha > betta) true_value = Math.Cos(n * Math.Asin(betta / alpha)) / n;
                else
                {
                    true_value = Math.Cos(Math.PI * n / 2) / n;
                    true_value *= Math.Pow(alpha / (betta + Math.Sqrt(betta * betta - alpha * alpha)), n);
                }
            }
        }

        static void WriteToFIle(string filename, string title, long time, double appr_value, double true_value, double B, double error, bool isAppend = false)
        {
            using (StreamWriter SW = new StreamWriter(filename, isAppend))
            {
                SW.WriteLine($" {title}  time = {time} millisec");
                SW.WriteLine($"  appr = {appr_value,22:F16}  B ={B,12:F1}");
                SW.WriteLine($" value = {true_value,22:F16}");
                SW.WriteLine($" error = {error,22:F16}\r\n");
            }
        }
    }
}

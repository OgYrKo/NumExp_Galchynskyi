using RP = NE_DLL.NE_Rectangular_Plate;
namespace NE_LW_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
            Variant();
        }

        static private void Test()
        {
            double T1 = 30.0, T2 = 20.0, T3 = -15.0, T4 = 15.0, a = 2, b = 1;
            int k1 = 5, k2 = 3, k3 = 1, k4 = 2;
            // Координати контрольних точок
            double xc1 = 1.0, yc1 = 0.2, xc2 = 1.5, yc2 = 0.75;

            RP plate = new RP(a, b, T1, T2, T3, T4, k1, k2, k3, k4);

            StreamWriter writer = new StreamWriter("Nodes_LW_04.txt");
            double t1 = plate.Txy(xc1, yc1), t2 = plate.Txy(xc2, yc2);
            writer.WriteLine($" t1 = {t1,18:F8}     t2 = {t2,18:F8}");
            writer.Close();

            writer = new StreamWriter("Map_LW_04.txt");
            int m = 400, i, j, M = (int)(a * m), N = (int)(b * m);
            double h = 1.0 / m, x = 0.0, y = 0.0;
            for (j = 0; j <= N; j++)
            {

                y = h * j;
                for (i = 0; i <= M; i++)
                {


                    x = h * i; t1 = plate.Txy(x, y);
                    writer.WriteLine($" {x,10:F6}   {y,10:F6}  {t1,12:F8}".Replace(',', '.'));
                }
            }
            writer.Close();
        }

        static private void Variant()
        {
            double T1 = 20.0, T2 = -10.0, T3 = 15.0, T4 = -5.0, a = 2, b = 1;
            int k1 = 3, k2 = 4, k3 = 5, k4 = 2;
            // Координати контрольних точок
            double xc1 = 0.15, yc1 = 0.75, xc2 = 1.85, yc2 = 0.25;

            RP plate = new RP(a, b, T1, T2, T3, T4, k1, k2, k3, k4);

            StreamWriter writer = new StreamWriter("Nodes_LW_04_V2.txt");
            double t1 = plate.Txy(xc1, yc1), t2 = plate.Txy(xc2, yc2);
            writer.WriteLine($" t1 = {t1,18:F8}     t2 = {t2,18:F8}");
            writer.Close();

            writer = new StreamWriter("Map_LW_04_V2.txt");
            int m = 200, i, j, M = (int)(a * m), N = (int)(b * m);
            double h = 1.0 / m, x = 0.0, y = 0.0;
            for (j = 0; j <= N; j++)
            {

                y = h * j;
                for (i = 0; i <= M; i++)
                {
                    x = h * i; t1 = plate.Txy(x, y);
                    writer.WriteLine($" {x,10:F6}   {y,10:F6}  {t1,12:F8}".Replace(',', '.'));
                }
            }
            writer.Close();
        }
    }
}

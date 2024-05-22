using ForceCalculation.Library;
using System.Numerics;

namespace ForceCalculation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int a = 4, modP1 = 8, modP2 = 16;
            ForceSystem fs = new ForceSystem();

            Force P1 = new Force(new Vector3(a, 0, 0), new Vector3(a, a, 0), modP1);
            Force P2 = new Force(new Vector3(a, a, 0), new Vector3(0, a, a), modP2);


            fs.AddForce(P1);
            fs.AddForce(P2);

            double x = fs.GetXProjection();
            double y = fs.GetYProjection();
            double z = fs.GetZProjection();
            double r = ForceSystem.GetR(x,y,z);
            Console.WriteLine("X: " + x);
            Console.WriteLine("Y: " + y);
            Console.WriteLine("Z: " + z);
            Console.WriteLine("R: " + r);
        }
    }
}

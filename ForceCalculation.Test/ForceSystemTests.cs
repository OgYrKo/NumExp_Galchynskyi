using ForceCalculation.Library;
using System.Numerics;

namespace ForceCalculation.Test
{
    public class ForceSystemTests
    {
        const int a = 30, b = 40, c = 20, modP1 = 8, modP2 = 4, modP3 = 6, modP4 = 20;
        ForceSystem fs;
        public ForceSystemTests()
        {
            fs = new ForceSystem();
            Force P1 = new Force(new Vector3(a, 0, 0), new Vector3(0, 0, 0), modP1);
            Force P2 = new Force(new Vector3(a, 0, c), new Vector3(a, b, c), modP2);
            Force P3 = new Force(new Vector3(a, b, c), new Vector3(a, b, 0), modP3);
            Force P4 = new Force(new Vector3(0, 0, c), new Vector3(a, b, c), modP4);

            fs.AddForce(P1);
            fs.AddForce(P2);
            fs.AddForce(P3);
            fs.AddForce(P4);
        }
        [Fact]
        public void CheckProjection()
        {
            double x=4, y = 20, z = -6;
            Assert.Equal(x, fs.GetXProjection());
            Assert.Equal(y, fs.GetYProjection());
            Assert.Equal(z, fs.GetZProjection());
            Assert.Equal(Math.Sqrt(x*x+y*y+z*z), fs.GetR());
        }

        [Fact]
        public void CheckMoment()
        {
            int M = 774;
            Assert.Equal(M, (int)fs.GetMomentum());

        }
    }
}

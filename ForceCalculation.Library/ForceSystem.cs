using System.Data;
using System.Numerics;

namespace ForceCalculation.Library
{
    public class ForceSystem
    {
        private List<Force> _forces;
        public ForceSystem()
        {
            _forces = new List<Force>();
        }
        public void AddForce(Force force)
        {
            _forces.Add(force);
        }

        public double GetXProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetXProjection();
            }
            return sum;
        }
        public double GetYProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetYProjection();
            }
            return sum;
        }
        public double GetZProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetZProjection();
            }
            return sum;
        }

        /// <summary>
        /// Receives projections of the main vector on coordinate axes and calculates the modulus of the main vector
        /// </summary>
        /// <returns>Modulus of the main vector</returns>
        public double GetR()
        {
            double x = GetXProjection();
            double y = GetYProjection();
            double z = GetZProjection();
            return GetR(x, y, z);
        }
        /// <summary>
        /// Calculate the modulus of the main vector
        /// </summary>
        /// <param name="x">x-axis projection</param>
        /// <param name="y">y-axis projection</param>
        /// <param name="z">z-axis projection</param>
        /// <returns>Modulus of the main vector</returns>
        public static double GetR(double x, double y, double z) => Math.Sqrt(x * x + y * y + z * z);
        public double GetMomentum()
        {
            Vector3 sum = Vector3.Zero;
            foreach (Force force in _forces)
            {
                sum += force.GetMomentum();
            }
            return sum.Length();
        }
    }
}

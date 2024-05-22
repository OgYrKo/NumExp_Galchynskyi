using System;
using System.Collections.Generic;
using System.Text;

namespace NE_DLL
{
    public class NE_Rectangular_Plate
    {
        readonly double T1, T2, T3, T4, a, b;
        readonly int k1, k2, k3, k4;
        readonly double al_1, al_2, bt_3, bt_4;

        public NE_Rectangular_Plate
        (double a, double b, double T1, double T2, double T3, double T4,
        int k1, int k2, int k3, int k4)
        {

            this.T1 = T1; this.T2 = T2; this.T3 = T3; this.T4 = T4; this.a = a;
            this.k1 = k1; this.k2 = k2; this.k3 = k3; this.k4 = k4; this.b = b;

            al_1 = Math.PI * k1 / a; al_2 = Math.PI * k2 / a;// формули (18)
            bt_3 = Math.PI * k3 / b; bt_4 = Math.PI * k4 / b;
        }

        public double Txy(double x, double y)
        {
            // формули (20) -(23)
            double t1 = Math.Exp(-al_1 * y) * (1.0 - Math.Exp(-2 * al_1 * (b - y))) / (1.0 - Math.Exp(-2 * al_1 * b));
            double t2 = Math.Exp(-al_2 * (b - y)) * (1.0 - Math.Exp(-2 * al_2 * y)) / (1.0 - Math.Exp(-2 * al_2 * b));
            double t3 = Math.Exp(-bt_3 * x) * (1.0 - Math.Exp(-2 * bt_3 * (a - x))) / (1.0 - Math.Exp(-2 * bt_3 * a));
            double t4 = Math.Exp(-bt_4 * (a - x)) * (1.0 - Math.Exp(-2 * bt_4 * x)) / (1.0 - Math.Exp(-2 * bt_4 * a));
            // формула (24)
            t1 *= T1 * Math.Sin(al_1 * x); t2 *= T2 * Math.Sin(al_2 * x);
            t3 *= T3 * Math.Sin(bt_3 * y); t4 *= T4 * Math.Sin(bt_4 * y);
            return t1 + t2 + t3 + t4;
        }
    }
}

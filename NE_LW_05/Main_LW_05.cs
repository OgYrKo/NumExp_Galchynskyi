using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJ = NE_DLL.NE_Method_Jacoby;

namespace NE_LW_05
{
  class Main_LW_05
  {
    static void Main(string[] args)
    {
      double T1 = 30.0, T2 = 20.0, T3 = -15.0, T4 = 15.0;
      double a = 2, b = 1;
      int k1 = 5, k2 = 3, k3 = 1, k4 = 2; int m = 300;

      double xc = 1.9, yc = 0.1; // Координати контрольної точки

      MJ Task = new MJ();

      Task.Rect_Plate(T1, T2, T3, T4, a, b, xc, yc, k1, k2, k3, k4, m, 1.0E-2, "Test");
    }
  }
}

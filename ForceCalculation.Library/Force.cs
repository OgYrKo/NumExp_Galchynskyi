using System.Numerics;

namespace ForceCalculation.Library
{
    public class Force
    {
        public string Name { get; init; } = "F?";
        public Vector3 StartPoint { get; init; }
        public Vector3 EndPoint { get; init; }
        private Vector3 Vector { get; init; }
        public int ForceValue { get; init; }
        public Force(Vector3 startPoint, Vector3 endPoint, int value)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Vector = endPoint - startPoint;
            ForceValue = value;
        }
        public Force(string name,Vector3 startPoint, Vector3 endPoint, int value)
        {
            Name = name;
            StartPoint = startPoint;
            Vector = endPoint - startPoint;
            ForceValue = value;
        }
        public double GetXProjection() => GetProjection(Vector.X, Vector.Y, Vector.Z, Vector.Length(), ForceValue);
        public double GetYProjection() => GetProjection(Vector.Y, Vector.X, Vector.Z, Vector.Length(), ForceValue);
        public double GetZProjection() => GetProjection(Vector.Z, Vector.Y, Vector.X, Vector.Length(), ForceValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectedAxisValue">Ось на которую проецируется вектор силы</param>
        /// <param name="projectingAxis1Value">Ось 1, которую проецируют</param>
        /// <param name="projectingAxis2Value">Ось 2, которую проецируют</param>
        /// <param name="vectorLength">Модуль вектора</param>
        /// <param name="forceValue">Сила (Н)</param>
        /// <returns>Проекция силы на проецирующую ось</returns>
        public static double GetProjection(double projectedAxisValue, double projectingAxis1Value, double projectingAxis2Value, double vectorLength, double forceValue)
        {
            if (projectedAxisValue == 0) return 0;
            else if (projectingAxis1Value == 0 && projectingAxis2Value == 0) return Math.Sign(projectedAxisValue) * forceValue;
            else if (projectingAxis1Value == 0 || projectingAxis2Value == 0) return forceValue * projectedAxisValue / vectorLength;
            else return forceValue * Math.Sqrt(projectingAxis1Value * projectingAxis1Value + projectingAxis2Value * projectingAxis2Value) / vectorLength;
        }
        public Vector3 GetMomentum()
        {
            Vector3 r = new Vector3((float)GetXProjection(), (float)GetYProjection(), (float)GetZProjection());
            return Vector3.Cross(StartPoint,r);
        }
        public override string ToString()
        {
            return $"Сила {Name} з модулем {ForceValue} Н, прикладена в точці {StartPoint} з направленням {Vector}";
        }
    }
}

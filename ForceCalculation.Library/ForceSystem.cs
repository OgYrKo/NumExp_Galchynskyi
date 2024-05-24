using Microsoft.Extensions.Logging;
using System.Data;
using System.Numerics;

namespace ForceCalculation.Library
{
    public class ForceSystem
    {
        private List<Force> _forces;
        private ILogger? _logger;
        
        public ForceSystem()
        {
            _forces = new List<Force>();
        }
        public ForceSystem(ILogger logger)
        {
            _forces = new List<Force>();
            _logger = logger;
            _logger?.LogInformation($"\r\n_________________________________________________________________________");
            _logger?.LogInformation($"Створено нову систему сил.");
        }

        public Force? Find(string forceName)
        {
            return _forces.Find(force => force.Name == forceName);
        }
        public void AddForce(Force force)
        {
            _forces.Add(force);
            _logger?.LogInformation($"Додано: {force}");
        }
        public void RemoveForce(string forceName)
        {
            Force? force = Find(forceName);
            if (force != null)
            {
                _forces.Remove(force);
                _logger?.LogInformation($"Видалено: {force.Name}");
            }
        }

        public double GetXProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetXProjection();
            }
            _logger?.LogInformation($"Проекція головного вектора на вісь X: {sum} Н");
            return sum;
        }
        public double GetYProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetYProjection();
            }
            _logger?.LogInformation($"Проекція головного вектора на вісь Y: {sum} Н");
            return sum;
        }
        public double GetZProjection()
        {
            double sum = 0;
            foreach (Force force in _forces)
            {
                sum += force.GetZProjection();
            }
            _logger?.LogInformation($"Проекція головного вектора на вісь Z: {sum} Н");
            return sum;
        }

        /// <summary>
        /// Receives projections of the main vector on coordinate axes and calculates the modulus of the main vector
        /// </summary>
        /// <returns>Modulus of the main vector</returns>
        public Vector3 GetR()
        {
            _logger?.LogInformation($"Визначення модуля та напрямку головного вектора заданої системи сил за його проекціями на координатні осі.");
            float x = (float)GetXProjection();
            float y = (float)GetYProjection();
            float z = (float)GetZProjection();
            Vector3 r = new Vector3(x, y, z);
            _logger?.LogInformation($"Модуль головного вектора: {r.Length()}");
            return r;
        }
        public Vector3 GetMomentum()
        {
            _logger?.LogInformation($"Визначення головного моменту сил відносно центру О.");
            Vector3 sumVector = Vector3.Zero;
            foreach (Force force in _forces)
            {
                sumVector += force.GetMomentum();
            }
            _logger?.LogInformation($"Відносно віссі X: {sumVector.X} Н/м");
            _logger?.LogInformation($"Відносно віссі Y: {sumVector.Y} Н/м");
            _logger?.LogInformation($"Відносно віссі Z: {sumVector.Z} Н/м");
            _logger?.LogInformation($"Модуль головного моменту сил: {sumVector.Length()} Н/м");
            return sumVector;
        }
        public Vector3 GetDynamic()
        {

            Vector3 r = GetR();
            Vector3 m = GetMomentum();
            Vector3 rm = r * m;
            if (rm.Length() != 0)
            {
                _logger?.LogInformation($"Так як R != 0 та M != 0");

                return rm / r.Length();
            }
            else
            {
                return Vector3.Zero;
                if (r.Length() == 0 && m.Length() == 0) return m;
            }

        }
    }
}

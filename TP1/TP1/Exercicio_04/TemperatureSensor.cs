using System;

namespace TP1
{
    public class TemperatureSensor
    {
        public delegate void TemperatureExceededHandler(double temperature);
        public event TemperatureExceededHandler? TemperatureExceeded;

        public void VerificarTemperatura(double temperatura)
        {
            Console.WriteLine($"Temperatura atual: {temperatura}°C");

            if (temperatura > 100)
            {
                OnTemperatureExceeded(temperatura);
            }
        }

        protected virtual void OnTemperatureExceeded(double temperatura)
        {
            TemperatureExceeded?.Invoke(temperatura);
        }
    }
}

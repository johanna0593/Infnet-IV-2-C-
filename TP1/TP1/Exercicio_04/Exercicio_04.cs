using System;
using TP1.Exercicio_04;

namespace TP1
{
    internal class Exercicio_04
    {
        internal void Start()
        {
            var sensor = new TemperatureSensor();

            // Assina o evento com um manipulador personalizado
            sensor.TemperatureExceeded += ExibirAlerta;

            Console.WriteLine("Digite temperaturas simuladas (digite 'sair' para encerrar):");

            while (true)
            {
                Console.Write("Temperatura: ");
                string? entrada = Console.ReadLine();

                if (entrada?.Trim().ToLower() == "sair")
                    break;

                if (double.TryParse(entrada, out double temperatura))
                {
                    sensor.VerificarTemperatura(temperatura);
                }
                else
                {
                    Console.WriteLine("Valor inválido. Digite um número ou 'sair'.");
                }
            }

            Console.WriteLine("Monitoramento encerrado.");
        }

        private void ExibirAlerta(double temperatura)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ALERTA: Temperatura crítica detectada: {temperatura}°C!");
            Console.ResetColor();
        }
    }
}

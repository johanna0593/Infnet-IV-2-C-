using System;

namespace TP1
{
    internal class Exercicio_03
    {
        internal void Start()
        {
            Console.WriteLine("=== Cálculo de Área de um Retângulo ===");

            double baseRetangulo = LerDouble("Informe a base do retângulo: ");
            double alturaRetangulo = LerDouble("Informe a altura do retângulo: ");

            // Func que calcula a área de um retângulo
            Func<double, double, double> calcularArea = (baseR, altura) => baseR * altura;

            double area = calcularArea(baseRetangulo, alturaRetangulo);

            Console.WriteLine($"\nA área do retângulo é: {area:F2}");
        }

        private double LerDouble(string mensagem)
        {
            double valor;
            Console.Write(mensagem);
            while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.Write("Valor inválido. Tente novamente: ");
            }
            return valor;
        }
    }
}

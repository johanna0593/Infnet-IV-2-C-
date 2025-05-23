using System;

namespace TP1
{
    // Delegate para cálculo de desconto
    public delegate decimal CalculateDiscount(decimal price);

    public class Exercicio_01
    {
        // Método compatível com o delegate
        public decimal Apply10PercentDiscount(decimal price)
        {
            return price * 0.9m; // Aplica 10% de desconto
        }

        public void Start()
        {
            Console.Write("Informe o preço original do produto: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal originalPrice))
            {
                CalculateDiscount discount = Apply10PercentDiscount;
                decimal finalPrice = discount(originalPrice);
                Console.WriteLine($"Preço com 10% de desconto: {finalPrice:C}");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }
    }
}

using System;

namespace TP1
{
    internal class Exercicio_06
    {
        internal void Start()
        {
            Console.WriteLine("=== Exercício 06: Multicast Delegate Logger ===");

            // Cria logger apontando para arquivo "log.txt" na pasta do executável
            var logger = new Logger("log.txt");

            // Define o Action<string> e adiciona os métodos
            Action<string> logDelegate = logger.LogToConsole;
            logDelegate += logger.LogToFile;
            logDelegate += logger.LogToDatabase;

            // Executa o delegate
            Console.Write("Digite a mensagem para log: ");
            string? msg = Console.ReadLine()?.Trim() ?? "";
            logDelegate(msg);

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}

using System;

namespace TP1
{
    internal class Exercicio_07
    {
        internal void Start()
        {
            Console.WriteLine("=== Exercício 07: Robustez na Invocação de Delegates ===");

            // Reúsa o Logger do Exercicio_06
            var logger = new Logger("log.txt");

            // 1) Teste sem métodos associados
            Action<string>? logDelegate = null;
            Console.WriteLine("Chamando delegate sem handlers (sem exceção):");
            logDelegate?.Invoke("Teste sem handlers");

            // 2) Agora adiciona os métodos
            logDelegate += logger.LogToConsole;
            logDelegate += logger.LogToFile;
            logDelegate += logger.LogToDatabase;

            Console.Write("\nDigite uma mensagem para log (agora com handlers): ");
            string? msg = Console.ReadLine()?.Trim() ?? "";
            // Invocação segura
            logDelegate?.Invoke(msg);

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}

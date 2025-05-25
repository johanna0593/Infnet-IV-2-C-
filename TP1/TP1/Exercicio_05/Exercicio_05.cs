using System;

namespace TP1
{
    internal class Exercicio_05
    {
        internal void Start()
        {
            var manager = new DownloadManager();

            // Assina o evento para exibir notificação
            manager.DownloadCompleted += FileDownloadCompleted;

            Console.Write("Informe o nome do arquivo para download: ");
            string fileName = Console.ReadLine()?.Trim() ?? "arquivo.txt";

            Console.Write("Informe o tempo de download em milissegundos: ");
            if (!int.TryParse(Console.ReadLine(), out int durationMs) || durationMs < 0)
            {
                durationMs = 2000; // valor padrão
            }

            manager.StartDownload(fileName, durationMs);

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private void FileDownloadCompleted(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"DOWNLOAD COMPLETO: '{fileName}' foi baixado com sucesso!");
            Console.ResetColor();
        }
    }
}

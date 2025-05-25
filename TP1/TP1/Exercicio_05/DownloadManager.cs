using System;
using System.Threading;

namespace TP1
{
    public class DownloadManager
    {
        // Delegate e evento para notificação de conclusão
        public delegate void DownloadCompletedHandler(string fileName);
        public event DownloadCompletedHandler? DownloadCompleted;

        public void StartDownload(string fileName, int durationMs)
        {
            Console.WriteLine($"Iniciando download de '{fileName}'...");

            // Simula o tempo de download
            Thread.Sleep(durationMs);

            // Ao final, dispara o evento
            OnDownloadCompleted(fileName);
        }

        protected virtual void OnDownloadCompleted(string fileName)
        {
            DownloadCompleted?.Invoke(fileName);
        }
    }
}

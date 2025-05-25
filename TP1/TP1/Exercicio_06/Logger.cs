using System;
using System.IO;

namespace TP1
{
    public class Logger
    {
        private readonly string _filePath;

        public Logger(string filePath)
        {
            _filePath = filePath;
        }

        // 1) Log no console
        public void LogToConsole(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }

        // 2) Log em arquivo
        public void LogToFile(string message)
        {
            File.AppendAllText(_filePath, $"[File] {message}{Environment.NewLine}");
        }

        // 3) Log simulado em “banco de dados”
        public void LogToDatabase(string message)
        {
            Console.WriteLine($"[Database] Gravando no banco: {message}");
        }
    }
}

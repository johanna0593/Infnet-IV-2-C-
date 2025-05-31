using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;

namespace Exercicio_11.Pages.FileManager
{
    public class ReadFilesModel : PageModel
    {
        // 1) Lista de nomes de todos os .txt em wwwroot/files
        public List<string> FileNames { get; set; } = new();

        // 2) O conteúdo do arquivo selecionado
        public string? FileContent { get; set; }

        // 3) OnGet recebe opcionalmente um parâmetro 'fileName' via query string
        public void OnGet(string? fileName)
        {
            // a) Constroi o caminho físico da pasta wwwroot/files
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            // b) Se a pasta existir, lista todos os arquivos .txt nela
            if (Directory.Exists(folderPath))
            {
                // Obtém apenas o nome (com extensão) de cada .txt
                FileNames = new List<string>();
                foreach (var fullPath in Directory.GetFiles(folderPath, "*.txt"))
                {
                    FileNames.Add(Path.GetFileName(fullPath));
                }
            }

            // c) Se o parâmetro fileName foi passado, tenta ler o conteúdo
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = Path.Combine(folderPath, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    // Lê todo o texto e armazena em FileContent
                    FileContent = System.IO.File.ReadAllText(filePath);
                }
                else
                {
                    FileContent = $"Arquivo \"{fileName}\" não encontrado.";
                }
            }
        }
    }
}

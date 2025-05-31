using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace Exercicio_10.Pages.NoteManager
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        public string? SavedFileName { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                ModelState.AddModelError("Content", "O conteúdo não pode ficar vazio.");
                return Page();
            }

            //    Exemplo: note-20230530123045.txt
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"note-{timestamp}.txt";

            //    Ex: C:\... \Exercicio_10\wwwroot\files\note-20230530123045.txt
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                System.IO.File.WriteAllText(filePath, Content);

                SavedFileName = fileName;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro ao salvar o arquivo: {ex.Message}");
                return Page();
            }

            return Page();
        }
    }
}

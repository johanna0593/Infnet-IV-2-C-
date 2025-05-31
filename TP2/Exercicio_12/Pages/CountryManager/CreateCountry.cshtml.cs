using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_12.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado com valida��es b�sicas de [Required].
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Objeto resultante ap�s submiss�o v�lida
        public Country? Country { get; set; }

        // GET: apenas exibe o formul�rio
        public void OnGet()
        {
        }

        // POST: processa o formul�rio e aplica valida��o customizada
        public IActionResult OnPost()
        {
            // Verificar se os Required passam antes da valida��o customizada
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Extrair primeira letra de cada campo (em mai�sculo para comparar sem case)
            var name = Input.CountryName.Trim();
            var code = Input.CountryCode.Trim();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
            {
                char firstLetterName = char.ToUpperInvariant(name[0]);
                char firstLetterCode = char.ToUpperInvariant(code[0]);

                if (firstLetterName != firstLetterCode)
                {
                    // 3) Adiciona erro espec�fico ao campo CountryCode
                    ModelState.AddModelError(
                        "Input.CountryCode",
                        "O c�digo do pa�s deve come�ar com a mesma letra do nome do pa�s."
                    );
                    return Page();
                }
            }

            // Se passou em todas as valida��es, cria o objeto Country
            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            // Exibe a p�gina (com objeto Country preenchido para mostrar a mensagem de sucesso)
            return Page();
        }

        // InputModel para receber os dados do formul�rio
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // Classe de dom�nio para exibir, se necess�rio, os dados v�lidos
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

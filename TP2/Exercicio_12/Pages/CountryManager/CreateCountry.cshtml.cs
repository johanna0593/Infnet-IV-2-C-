using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_12.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado com validações básicas de [Required].
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Objeto resultante após submissão válida
        public Country? Country { get; set; }

        // GET: apenas exibe o formulário
        public void OnGet()
        {
        }

        // POST: processa o formulário e aplica validação customizada
        public IActionResult OnPost()
        {
            // Verificar se os Required passam antes da validação customizada
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Extrair primeira letra de cada campo (em maiúsculo para comparar sem case)
            var name = Input.CountryName.Trim();
            var code = Input.CountryCode.Trim();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
            {
                char firstLetterName = char.ToUpperInvariant(name[0]);
                char firstLetterCode = char.ToUpperInvariant(code[0]);

                if (firstLetterName != firstLetterCode)
                {
                    // 3) Adiciona erro específico ao campo CountryCode
                    ModelState.AddModelError(
                        "Input.CountryCode",
                        "O código do país deve começar com a mesma letra do nome do país."
                    );
                    return Page();
                }
            }

            // Se passou em todas as validações, cria o objeto Country
            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            // Exibe a página (com objeto Country preenchido para mostrar a mensagem de sucesso)
            return Page();
        }

        // InputModel para receber os dados do formulário
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // Classe de domínio para exibir, se necessário, os dados válidos
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

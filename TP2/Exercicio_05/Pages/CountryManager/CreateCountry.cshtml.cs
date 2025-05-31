using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_05.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado para receber dados do formulário
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Depois de submeter, armazenaremos aqui a instância de Country
        public Country? Country { get; set; }

        // GET: apenas exibe o formulário
        public void OnGet()
        {
        }

        // POST: processa o formulário
        public IActionResult OnPost()
        {
            // Se falhar na validação, retorna à página mostrando erros
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se está válido, criamos a instância de Country a partir do InputModel
            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            // Continua na mesma página para exibir o Country criado
            return Page();
        }

        // 3) Classe interna para validação básica (será ampliada no Exercício 6)
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // 4) Classe que representa o modelo de domínio (o objeto complexo)
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

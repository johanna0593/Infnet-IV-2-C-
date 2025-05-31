using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_06.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado: armazena os dados recebidos do formulário
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Após submissão bem-sucedida, armazenamos aqui a instância de Country
        public Country? Country { get; set; }

        // Quando a página for aberta via GET
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2,
                ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

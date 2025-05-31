using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_06.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado: armazena os dados recebidos do formul�rio
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Ap�s submiss�o bem-sucedida, armazenamos aqui a inst�ncia de Country
        public Country? Country { get; set; }

        // Quando a p�gina for aberta via GET
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
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            [StringLength(2, MinimumLength = 2,
                ErrorMessage = "O c�digo do pa�s deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

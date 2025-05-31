using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio_04.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public bool Submitted { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Submitted = true;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
            public string CityName { get; set; } = string.Empty;
        }
    }
}

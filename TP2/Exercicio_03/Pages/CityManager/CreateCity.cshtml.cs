using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio_03.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        // Usamos um InputModel aninhado para aplicar DataAnnotations
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // Flag para controlar se já houve tentativa de submit
        public bool Submitted { get; set; }

        // Quando a página for acessada via GET
        public void OnGet()
        {
            // Nada a fazer aqui, apenas exibe o formulário vazio
        }

        // Quando o formulário for submetido via POST
        public IActionResult OnPost()
        {
            Submitted = true;

            // Se ModelState não for válido, retorna para a página exibindo erros
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se passou na validação, podemos processar o dado
            // (neste exercício, basta exibir a cidade cadastrada)
            return Page();
        }

        // Classe interna para receber dados e aplicar DataAnnotations
        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
            public string CityName { get; set; } = string.Empty;
        }
    }
}

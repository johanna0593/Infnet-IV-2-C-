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

        // Flag para controlar se j� houve tentativa de submit
        public bool Submitted { get; set; }

        // Quando a p�gina for acessada via GET
        public void OnGet()
        {
            // Nada a fazer aqui, apenas exibe o formul�rio vazio
        }

        // Quando o formul�rio for submetido via POST
        public IActionResult OnPost()
        {
            Submitted = true;

            // Se ModelState n�o for v�lido, retorna para a p�gina exibindo erros
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se passou na valida��o, podemos processar o dado
            // (neste exerc�cio, basta exibir a cidade cadastrada)
            return Page();
        }

        // Classe interna para receber dados e aplicar DataAnnotations
        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade � obrigat�rio.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter no m�nimo 3 caracteres.")]
            public string CityName { get; set; } = string.Empty;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_05.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        // 1) InputModel aninhado para receber dados do formul�rio
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // 2) Depois de submeter, armazenaremos aqui a inst�ncia de Country
        public Country? Country { get; set; }

        // GET: apenas exibe o formul�rio
        public void OnGet()
        {
        }

        // POST: processa o formul�rio
        public IActionResult OnPost()
        {
            // Se falhar na valida��o, retorna � p�gina mostrando erros
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se est� v�lido, criamos a inst�ncia de Country a partir do InputModel
            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            // Continua na mesma p�gina para exibir o Country criado
            return Page();
        }

        // 3) Classe interna para valida��o b�sica (ser� ampliada no Exerc�cio 6)
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // 4) Classe que representa o modelo de dom�nio (o objeto complexo)
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

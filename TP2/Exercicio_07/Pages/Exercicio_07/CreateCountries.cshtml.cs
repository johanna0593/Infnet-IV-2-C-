using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_07.Pages.CountryManager
{
    public class CreateCountriesModel : PageModel
    {
        // 1) BindProperty para lista de 5 InputModel
        [BindProperty]
        public List<InputModel> Countries { get; set; } = new();

        // 2) Ap�s o POST bem-sucedido, armazenaremos aqui a lista enviada
        public List<Country>? SubmittedCountries { get; set; }

        // GET: quando a p�gina for aberta
        public void OnGet()
        {
            // Inicializa a lista com 5 entradas vazias
            Countries = new List<InputModel>();
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        // POST: quando o formul�rio for submetido
        public IActionResult OnPost()
        {
            // Se ModelState n�o for v�lido, exibe a p�gina novamente (com erros)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se v�lido, converte cada InputModel em um Country de dom�nio
            SubmittedCountries = new List<Country>();
            foreach (var input in Countries)
            {
                // (Opcional) voc� pode ignorar linhas vazias, mas aqui vamos
                // assumir que todos os 5 foram preenchidos corretamente.
                SubmittedCountries.Add(new Country
                {
                    CountryName = input.CountryName,
                    CountryCode = input.CountryCode
                });
            }

            // Retorna a mesma p�gina, agora com SubmittedCountries preenchida
            return Page();
        }

        // Classe interna para receber cada linha do formul�rio
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            [StringLength(2, MinimumLength = 2,
                ErrorMessage = "O c�digo do pa�s deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // Classe de dom�nio para exibir o que foi submetido
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

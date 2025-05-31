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

        // 2) Após o POST bem-sucedido, armazenaremos aqui a lista enviada
        public List<Country>? SubmittedCountries { get; set; }

        // GET: quando a página for aberta
        public void OnGet()
        {
            // Inicializa a lista com 5 entradas vazias
            Countries = new List<InputModel>();
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        // POST: quando o formulário for submetido
        public IActionResult OnPost()
        {
            // Se ModelState não for válido, exibe a página novamente (com erros)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se válido, converte cada InputModel em um Country de domínio
            SubmittedCountries = new List<Country>();
            foreach (var input in Countries)
            {
                // (Opcional) você pode ignorar linhas vazias, mas aqui vamos
                // assumir que todos os 5 foram preenchidos corretamente.
                SubmittedCountries.Add(new Country
                {
                    CountryName = input.CountryName,
                    CountryCode = input.CountryCode
                });
            }

            // Retorna a mesma página, agora com SubmittedCountries preenchida
            return Page();
        }

        // Classe interna para receber cada linha do formulário
        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2,
                ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        // Classe de domínio para exibir o que foi submetido
        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}

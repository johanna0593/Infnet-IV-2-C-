using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Exercicio_09.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } = new List<string>
        {
            "Rio de Janeiro",
            "São Paulo",
            "Brasília",
            "Curitiba",
            "Salvador"
        };

        public void OnGet()
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio_09.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
       
        public string CityName { get; set; } = string.Empty;

       
        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}

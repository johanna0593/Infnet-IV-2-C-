using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio_02.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        public string? CityName { get; set; }

        public void OnPost(string cityName)
        {
            CityName = cityName;
        }
    }
}

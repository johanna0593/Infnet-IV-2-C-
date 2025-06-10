using CityBreaks.Web.Data;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;

        public CityDetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public City? City { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }  // Recebe o parâmetro da URL

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToPage("/Index");
            }

            City = await _cityService.GetByNameAsync(Name);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

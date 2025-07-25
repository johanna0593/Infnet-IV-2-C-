using CityBreaks.Web.Data;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public FilterPropertiesModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CityName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PropertyName { get; set; }

        public List<Property> Properties { get; set; }

        public async Task OnGetAsync()
        {
            Properties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
        }
    }
}

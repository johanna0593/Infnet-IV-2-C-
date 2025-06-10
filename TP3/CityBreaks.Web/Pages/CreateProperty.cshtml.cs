using CityBreaks.Web.Data;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property NewProperty { get; set; }

        // Lista de cidades para dropdown
        public SelectList CitiesSelectList { get; set; }

        public async Task OnGetAsync()
        {
            // Buscar cidades para popular o dropdown
            var cities = await _context.Cities.ToListAsync();
            CitiesSelectList = new SelectList(cities, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Recarrega o dropdown se der erro
                var cities = await _context.Cities.ToListAsync();
                CitiesSelectList = new SelectList(cities, "Id", "Name");
                return Page();
            }

            // Adiciona a nova propriedade
            _context.Properties.Add(NewProperty);
            await _context.SaveChangesAsync();

            // Redireciona para a Index ou outra página que desejar
            return RedirectToPage("Index");
        }
    }
}

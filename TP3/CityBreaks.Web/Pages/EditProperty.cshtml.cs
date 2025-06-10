using CityBreaks.Web.Data;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property? property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            Property = property;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propertyToUpdate = await _context.Properties.FindAsync(id);

            if (propertyToUpdate == null)
            {
                return NotFound();
            }

            // Atualiza apenas os campos que você permite
            if (await TryUpdateModelAsync<Property>(
                propertyToUpdate,
                "property",   // prefixo para BindProperty
                p => p.Name,
                p => p.Description,
                p => p.Price))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}

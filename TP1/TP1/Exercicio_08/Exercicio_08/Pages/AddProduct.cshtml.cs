using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductCatalog.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string Nome { get; set; }

        [BindProperty]
        public decimal Preco { get; set; }

        public bool ProdutoCadastrado { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ProdutoCadastrado = true;
        }
    }
}

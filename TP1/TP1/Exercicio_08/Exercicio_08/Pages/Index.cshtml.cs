using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public List<(string Nome, decimal Preco)> Produtos { get; set; }

    public void OnGet()
    {
        Produtos = new List<(string, decimal)>
        {
            ("Produto A", 25.00m),
            ("Produto B", 40.00m),
            ("Produto C", 15.00m)
        };
    }
}

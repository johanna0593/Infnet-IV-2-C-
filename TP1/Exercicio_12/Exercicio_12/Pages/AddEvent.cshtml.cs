using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

public class AddEventModel : PageModel
{
    public class Evento
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
    }

    [BindProperty]
    public Evento Evento { get; set; }

    public bool EventoCriado { get; set; } = false;

    // Delegate estático
    public static Action<Evento> OnEventoCriado;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        EventoCriado = true;

        // Disparar o evento
        OnEventoCriado?.Invoke(Evento);

        return Page();
    }
}

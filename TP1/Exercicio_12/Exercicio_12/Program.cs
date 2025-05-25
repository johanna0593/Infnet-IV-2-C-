var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


Exercicio_12.Pages.AddEventModel.OnEventoCriado += (evento) =>
{
    Console.WriteLine($"[LOG] Evento criado: {evento.Titulo}, {evento.Data.ToShortDateString()}, {evento.Local}");
};

app.Run();

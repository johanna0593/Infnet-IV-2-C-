using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Exercício 2 – Configurando o contexto do banco de dados com Sqlite
builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Exercício 2 – Registrando Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Exercício 2 – Configurações padrão do pipeline HTTP
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

app.Run();

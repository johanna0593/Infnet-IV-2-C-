using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Exerc�cio 2 � Configurando o contexto do banco de dados com Sqlite
builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Exerc�cio 2 � Registrando Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Exerc�cio 2 � Configura��es padr�o do pipeline HTTP
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

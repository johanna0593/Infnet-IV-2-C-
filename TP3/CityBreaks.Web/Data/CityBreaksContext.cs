using CityBreaks.Web.Data.Configurations; // Correto namespace usado em todo o projeto
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data
{
    public class CityBreaksContext : DbContext
    {
        public CityBreaksContext(DbContextOptions<CityBreaksContext> options) : base(options) { }

        // Exercício 3 – Adicionando as entidades Country e Property ao DbContext
        public DbSet<Country> Countries { get; set; }
        public DbSet<Property> Properties { get; set; }

        // Exercício 5 – Aplicando as configurações de entidade com Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        }
    }
}

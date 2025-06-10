using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityBreaks.Web.Data
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Chave estrangeira para a cidade
        public int CityId { get; set; }

        // Navegação para a cidade
        public City? City { get; set; }

        // Se for implementar exclusão lógica depois
        public DateTime? DeletedAt { get; set; }
    }
}

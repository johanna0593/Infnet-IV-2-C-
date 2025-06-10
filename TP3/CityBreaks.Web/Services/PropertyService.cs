using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetAllActiveAsync()
        {
            return await _context.Properties
                .Where(p => p.DeletedAt == null)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                property.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName)
        {
            IQueryable<Property> query = _context.Properties
                .Include(p => p.City)
                .Where(p => p.DeletedAt == null); // para ignorar propriedades excluídas logicamente

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                query = query.Where(p => EF.Functions.Collate(p.City.Name, "NOCASE").Contains(cityName));
            }

            if (!string.IsNullOrEmpty(propertyName))
            {
                query = query.Where(p => EF.Functions.Collate(p.Name, "NOCASE").Contains(propertyName));
            }

            return await query.ToListAsync();
        }
    }
}

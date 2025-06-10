using CityBreaks.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllActiveAsync();
        Task DeleteAsync(int id);
        // Aqui depois você pode adicionar outros métodos, tipo Create, Update, etc.
    }
}

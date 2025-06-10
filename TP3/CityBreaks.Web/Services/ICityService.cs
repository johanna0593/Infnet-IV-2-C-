using CityBreaks.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByNameAsync(string name);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCities();
        Task AddCity(City city);
        Task<City> GetCurrentCity(string name);
    }
}
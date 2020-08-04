using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Repository.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> GetCurrentCity(string name);
        Task AddCity(City city);
    }
}
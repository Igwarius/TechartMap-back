using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Repository.Interfaces
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetCinemas();
        Task<Cinema> GetCurrentCinema(string name);
        Task AddCinema(Cinema cinema);
        Task<Cinema> GetCurrentCinemaByCity(string cityName);
    }
}
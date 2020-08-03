using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetCinemas();
        Task AddCinema(Cinema cinema);
        Task<Cinema> GetCurrentCinema(string name);
        Task<IEnumerable<Cinema>> GetCinemasByCity(string cityName);
    }
}
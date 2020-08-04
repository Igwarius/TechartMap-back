using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetFilms();
        Task AddFilm(Film film);
        Task<Film> GetCurrentFilm(string name);
    }
}
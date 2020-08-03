using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Repository.Interfaces
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetFilms();
        Task<Film> GetCurrentFilm(string name);
        Task AddFilm(Film film);
   
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _FilmRepository;

        public FilmService(IFilmRepository FilmRepository)
        {
            _FilmRepository = FilmRepository;
        }

        public async Task<IEnumerable<Film>> GetFilms()
        {
            return await _FilmRepository.GetFilms();
        }

        public async Task<Film> GetCurrentFilm(string name)
        {
            var foundFilm = await _FilmRepository.GetCurrentFilm(name);

            return foundFilm;
        }

        public async Task AddFilm(Film film)
        {
            await _FilmRepository.AddFilm(new Film
            {
                Name = film.Name,
                Sessions = film.Sessions,
                StartDate = film.StartDate,
                EndDate = film.EndDate,
                AgeLimit = film.AgeLimit,
                Genre = film.Genre
            });
        }
    }
}
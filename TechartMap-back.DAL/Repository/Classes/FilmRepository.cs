using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class FilmRepository:IFilmRepository
    {
        private readonly Context.Context _context;
        public FilmRepository(Context.Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Film>> GetFilms()
        {
            return await Task.FromResult(_context.Films);
        }

        public async Task<Film> GetCurrentFilm(string name)
        {
            var film = await _context.Films.FirstOrDefaultAsync(a => a.Name == name);
            return film;
        }

        public async Task AddFilm(Film film)
        {
            var existingFilm = await _context.Films.FirstOrDefaultAsync(x => x.Name == film.Name);

            if (existingFilm == null) await _context.Films.AddAsync(film);

            await _context.SaveChangesAsync();
        }

    }
}
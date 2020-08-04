using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly Context.Context _context;

        public CinemaRepository(Context.Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            return await Task.FromResult(_context.Cinemas);
        }

        public async Task<Cinema> GetCurrentCinema(string name)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(a => a.Name == name);
            return cinema;
        }

        public async Task AddCinema(Cinema cinema)
        {
            var existingCinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Name == cinema.Name);

            if (existingCinema == null) await _context.Cinemas.AddAsync(cinema);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemasByCity(string cityName)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(a => a.Name == cityName);
            var cinemas = await Task.FromResult(_context.Cinemas.Where(a => a.CityId == city.Id));
            return cinemas;
        }
    }
}
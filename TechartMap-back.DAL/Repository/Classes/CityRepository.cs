using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class CityRepository :ICityRepository
    {
        private readonly Context.Context _context;
        public CityRepository(Context.Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCities()
        {
            return await Task.FromResult(_context.Cities);
        }

        public async Task<City> GetCurrentCity(string name)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(a => a.Name == name);
            return city;
        }

        public async Task AddCity(City city)
        {
            var existingCity = await _context.Cities.FirstOrDefaultAsync(x => x.Name == city.Name);

            if (existingCity == null) await _context.Cities.AddAsync(city);

            await _context.SaveChangesAsync();
        }

        

       
    }
}
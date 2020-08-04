using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _cityRepository.GetCities();
        }

        public async Task<City> GetCurrentCity(string name)
        {
            var foundCity = await _cityRepository.GetCurrentCity(name);

            return foundCity;
        }

        public async Task AddCity(City city)
        {
            await _cityRepository.AddCity(new City
            {
                Name = city.Name
            });
        }
    }
}
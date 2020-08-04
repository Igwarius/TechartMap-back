using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository CinemaRepository)
        {
            _cinemaRepository = CinemaRepository;
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            return await _cinemaRepository.GetCinemas();
        }

        public async Task<Cinema> GetCurrentCinema(string name)
        {
            var foundCinema = await _cinemaRepository.GetCurrentCinema(name);

            return foundCinema;
        }

        public async Task AddCinema(Cinema cinema)
        {
            await _cinemaRepository.AddCinema(new Cinema
            {
                Name = cinema.Name,
                CityId = cinema.CityId
            });
        }

        public async Task<IEnumerable<Cinema>> GetCinemasByCity(string cityName)
        {
            return await _cinemaRepository.GetCinemasByCity(cityName);
        }
    }
}
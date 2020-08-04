using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<IEnumerable<Hall>> GetHalls()
        {
            return await _hallRepository.GetHalls();
        }

        public async Task<Hall> GetCurrentHall(int number)
        {
            var foundHall = await _hallRepository.GetCurrentHall(number);

            return foundHall;
        }

        public async Task AddHall(Hall hall)
        {
            await _hallRepository.AddHall(new Hall
            {
                Number = hall.Number,
                CinemaId = hall.CinemaId,
                Cinema = hall.Cinema,
                Sessions = hall.Sessions,
                Rows = hall.Rows
            });
        }

        public async Task<IEnumerable<Row>> GetRows()
        {
            return await _hallRepository.GetRows();
        }

        public async Task<Row> GetCurrentRow(int number)
        {
            var foundRow = await _hallRepository.GetCurrentRow(number);

            return foundRow;
        }

        public async Task AddRow(Row row)
        {
            await _hallRepository.AddRow(new Row
            {
                Number = row.Number,
                HallId = row.HallId
            });
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await _hallRepository.GetPlaces();
        }

        public async Task<Place> GetCurrentPlace(int number)
        {
            var foundPlace = await _hallRepository.GetCurrentPlace(number);

            return foundPlace;
        }

        public async Task AddPlace(Place place)
        {
            await _hallRepository.AddPlace(new Place
            {
                Number = place.Number,
                PlaceType = place.PlaceType,
                Row = place.Row,
                RowId = place.RowId
            });
        }
    }
}
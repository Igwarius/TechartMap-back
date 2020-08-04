using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface IHallService
    {
        Task<IEnumerable<Hall>> GetHalls();
        Task<Hall> GetCurrentHall(int number);
        Task AddHall(Hall hall);
        Task<IEnumerable<Row>> GetRows();
        Task<Row> GetCurrentRow(int number);
        Task AddRow(Row row);
        Task<IEnumerable<Place>> GetPlaces();
        Task<Place> GetCurrentPlace(int number);
        Task AddPlace(Place place);
    }
}
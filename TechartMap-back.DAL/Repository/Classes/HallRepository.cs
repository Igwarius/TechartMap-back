using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class HallRepository : IHallRepository
    {
        private readonly Context.Context _context;

        public HallRepository(Context.Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hall>> GetHalls()
        {
            return await Task.FromResult(_context.Halls);
        }

        public async Task<Hall> GetCurrentHall(int number)
        {
            var hall = await _context.Halls.FirstOrDefaultAsync(a => a.Number == number);
            return hall;
        }

        public async Task AddHall(Hall hall)
        {
            await _context.Halls.AddAsync(hall);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Row>> GetRows()
        {
            return await Task.FromResult(_context.Rows);
        }

        public async Task<Row> GetCurrentRow(int number)
        {
            var Row = await _context.Rows.FirstOrDefaultAsync(a => a.Number == number);
            return Row;
        }

        public async Task AddRow(Row row)
        {
            await _context.Rows.AddAsync(row);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await Task.FromResult(_context.Places);
        }

        public async Task<Place> GetCurrentPlace(int number)
        {
            var Place = await _context.Places.FirstOrDefaultAsync(a => a.Number == number);
            return Place;
        }

        public async Task AddPlace(Place place)
        {
            await _context.Places.AddAsync(place);

            await _context.SaveChangesAsync();
        }
    }
}
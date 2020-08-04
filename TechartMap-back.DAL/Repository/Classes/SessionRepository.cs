using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class SessionRepository :ISessionRepository
    {
        private readonly Context.Context _context;
        public SessionRepository(Context.Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Session>> GetSessions()
        {
            return await Task.FromResult(_context.Sessions);
        }

        public async Task<Session> GetCurrentSession(int id)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(a => a.Id == id);
            return session;
        }

        public async Task AddSession(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task<List<List<PlaceResponse>>> GetHallBySession(int id)
        {
            var hallList = new List<List<PlaceResponse>>();
        var session = await _context.Sessions.FirstOrDefaultAsync(a => a.Id == id);
        var hall= await _context.Halls.FirstOrDefaultAsync(x => x.Id == session.HallId);
        var allRows = _context.Rows.Where(x => x.HallId == hall.Id);
        foreach (var row in allRows)
        {
           var rowList = new List<PlaceResponse>();
                var allPlaces = _context.Places.Where(a => a.RowId == row.Id);
            foreach (var place in allPlaces)
            {
                var transact = await _context.Transactions.FirstOrDefaultAsync(a => a.PlaceId == place.Id);
                var isFree = transact == null;
                var placeResponse = new PlaceResponse(place.Number, isFree, place.PlaceType);
                rowList.Add(placeResponse);
                } 
            hallList.Add(rowList);
        }

        return hallList;
        }
    }
}
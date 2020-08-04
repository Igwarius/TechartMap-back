using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetSessions();
        Task<Session> GetCurrentSession(int id);
        Task AddSession(Session session);
        Task<List<List<PlaceResponse>>> GetHallBySession(int id);
    }
}
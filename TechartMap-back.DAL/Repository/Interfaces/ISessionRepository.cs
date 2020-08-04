using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Repository.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetSessions();
        Task<Session> GetCurrentSession(int id);
        Task AddSession(Session session);
        Task<List<List<PlaceResponse>>> GetHallBySession(int id);
    }
}
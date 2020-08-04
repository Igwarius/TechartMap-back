using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<Session>> GetSessions()
        {
            return await _sessionRepository.GetSessions();
        }

        public async Task<Session> GetCurrentSession(int id)
        {
            var foundSession = await _sessionRepository.GetCurrentSession(id);

            return foundSession;
        }

        public async Task AddSession(Session session)
        {
            await _sessionRepository.AddSession(new Session
            {
                HallId = session.HallId,
                FilmId = session.FilmId,
                Price = session.Price,
                Date = session.Date,
                Film = session.Film,
                Hall = session.Hall
            });
        }

        public async Task<List<List<PlaceResponse>>> GetHallBySession(int id)
        {
            return await _sessionRepository.GetHallBySession(id);
        }
    }
}
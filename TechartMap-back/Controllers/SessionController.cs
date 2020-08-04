using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("session")]
    [ApiController]
    public class SessionController: Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet]
        [Route("sessions")]
        public async Task<IActionResult> GetAllSessions()
        {
            var cities = await _sessionService.GetSessions();
            return Ok(cities);
        }
        [HttpGet]
        [Route("session/{id}")]
        public async Task<IActionResult> GetSession(int id)
        {
            var sessions = await _sessionService.GetCurrentSession(id);
            return Ok(sessions);
        }
        [HttpGet]
        [Route("hall-by-session/{id}")]
        public async Task<IActionResult> GetSessionByCity(int id)
        {
            var hall = await _sessionService.GetHallBySession(id);
            return Ok(hall);
        }
        [HttpPost]
        [Route("session")]
        public async Task<IActionResult> AddSession([FromBody] Session Session)
        {
            await _sessionService.AddSession(Session);
            return Ok();
        }
    }
}
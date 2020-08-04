using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("film")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        [Route("films")]
        public async Task<IActionResult> GetAllFilms()
        {
            var cities = await _filmService.GetFilms();
            return Ok(cities);
        }

        [HttpGet]
        [Route("film/{name}")]
        public async Task<IActionResult> GetFilm(string name)
        {
            var film = await _filmService.GetCurrentFilm(name);
            return Ok(film);
        }

        [HttpPost]
        [Route("film")]
        public async Task<IActionResult> AddFilm([FromBody] Film film)
        {
            await _filmService.AddFilm(film);
            return Ok();
        }
    }
}
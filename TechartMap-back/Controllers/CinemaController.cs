using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("cinema")]
    [ApiController]
    public class CinemaController:Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        [HttpGet]
        [Route("cinemas")]
        public async Task<IActionResult> GetAllCinemas()
        {
            var cities = await _cinemaService.GetCinemas();
            return Ok(cities);
        }
        [HttpGet]
        [Route("cinema/{name}")]
        public async Task<IActionResult> GetCinema(string name)
        {
            var cinemas = await _cinemaService.GetCurrentCinema(name);
            return Ok(cinemas);
        }
        [HttpGet]
        [Route("cinema-by-city/{cityName}")]
        public async Task<IActionResult> GetCinemaByCity(string cityName)
        {
            var cinemas = await _cinemaService.GetCinemasByCity(cityName);
            return Ok(cinemas);
        }
        [HttpPost]
        [Route("cinema")]
        public async Task<IActionResult> AddCinema([FromBody] Cinema cinema)
        {
            await _cinemaService.AddCinema(cinema);
            return Ok();
        }
    }
}

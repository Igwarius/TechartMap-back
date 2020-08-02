using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("city")]
    [ApiController]
    public class CityController:Controller
    {
        private readonly ICityService _CityService;

        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }
        [HttpGet]
        [Route("cities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _CityService.GetCities();
            return Ok(cities);
        }
        [HttpGet]
        [Route("city/{name}")]
        public async Task<IActionResult> GetCity(string name)
        {
            var Citys = await _CityService.GetCurrentCity(name);
            return Ok(Citys);
        }

        [HttpPost]
        [Route("City")]
        public async Task<IActionResult> AddCity([FromBody] City city)
        {
            await _CityService.AddCity(city);
            return Ok();
        }
    }
}

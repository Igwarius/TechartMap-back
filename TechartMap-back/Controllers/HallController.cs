using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("hall")]
    [ApiController]
    public class HallController : Controller
    {
        private readonly IHallService _hallService;

        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        [Route("halls")]
        public async Task<IActionResult> GetAllHalls()
        {
            var cities = await _hallService.GetHalls();
            return Ok(cities);
        }

        [HttpGet]
        [Route("hall/{number}")]
        public async Task<IActionResult> GetHall(int number)
        {
            var halls = await _hallService.GetCurrentHall(number);
            return Ok(halls);
        }

        [HttpPost]
        [Route("hall")]
        public async Task<IActionResult> AddHall([FromBody] Hall hall)
        {
            await _hallService.AddHall(hall);
            return Ok();
        }

        [HttpGet]
        [Route("rows")]
        public async Task<IActionResult> GetAllRows()
        {
            var cities = await _hallService.GetRows();
            return Ok(cities);
        }

        [HttpGet]
        [Route("row/{number}")]
        public async Task<IActionResult> GetRow(int number)
        {
            var Rows = await _hallService.GetCurrentRow(number);
            return Ok(Rows);
        }

        [HttpPost]
        [Route("row")]
        public async Task<IActionResult> AddRow([FromBody] Row row)
        {
            await _hallService.AddRow(row);
            return Ok();
        }

        [HttpGet]
        [Route("places")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var cities = await _hallService.GetPlaces();
            return Ok(cities);
        }

        [HttpGet]
        [Route("place/{number}")]
        public async Task<IActionResult> GetPlace(int number)
        {
            var Places = await _hallService.GetCurrentPlace(number);
            return Ok(Places);
        }

        [HttpPost]
        [Route("place")]
        public async Task<IActionResult> AddPlace([FromBody] Place place)
        {
            await _hallService.AddPlace(place);
            return Ok();
        }
    }
}
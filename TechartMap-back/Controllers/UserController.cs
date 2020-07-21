using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> CheckUser([FromBody] User user)
        {
            var response = await _userService.CheckUser(user);
            if (response != null) return Ok(response);
            return NotFound();
        }
    }
}
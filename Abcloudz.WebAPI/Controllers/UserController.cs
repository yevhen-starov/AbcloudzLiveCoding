using Microsoft.AspNetCore.Mvc;
using Abcloudz.WebAPI.Models;
using Abcloudz.WebAPI.Services;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] UserQuery query)
        {
            var users = _userService.GetUsers(query);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userService.CreateUser(request.Name, request.Email);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}

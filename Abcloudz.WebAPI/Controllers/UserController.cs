using Abcloudz.WebAPI.Commands;
using Abcloudz.WebAPI.Queries;
using Abcloudz.WebAPI.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(UserRepository repository) : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        public IEnumerable<UserInfoDto> GetUsers([FromQuery] UserInfoFilterModel filterModel)
        {
            return new GetUsersQuery(repository).Handle(filterModel);
        }
        
        [HttpPost]
        public IActionResult AddUser(AddUserDto userDto)
        {
            new AddUserCommand(repository).Handle(userDto);
            return Ok();
        }
    }
}

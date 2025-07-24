using Abcloudz.WebAPI.Commands;
using Abcloudz.WebAPI.Queries;
using Abcloudz.WebAPI.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers;

[ApiController]
public class UserController(UserRepository repository) : ControllerBase
{
    [HttpGet]
    [Route("users")]
    public Task<IEnumerable<UserInfoDto>> GetUsers([FromQuery] UserInfoFilterModel filterModel) 
        => new GetUsersQuery(repository).Handle(filterModel);

    [HttpPost]
    [Route("add-user")]
    public Task AddUser(AddUserDto userDto) => new AddUserCommand(repository).Handle(userDto);
}
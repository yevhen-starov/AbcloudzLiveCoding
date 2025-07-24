using Abcloudz.Application;
using Abcloudz.Application.Commands;
using Abcloudz.Application.Domain;
using Abcloudz.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers;

[ApiController]
public class UserController(IRepository<User> repository) : ControllerBase
{
    [HttpGet]
    [Route("users")]
    public Task<IEnumerable<UserInfoDto>> GetUsers([FromQuery] UserInfoFilterModel filterModel) 
        => new GetUsersQuery(repository).Handle(filterModel);

    [HttpPost]
    [Route("add-user")]
    public Task AddUser(AddUserDto userDto) => new AddUserCommand(repository).Handle(userDto);
}
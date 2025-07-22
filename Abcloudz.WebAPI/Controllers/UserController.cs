using Abcloudz.WebAPI.Application.Commands.Users.CreateUser;
using Abcloudz.WebAPI.Application.Queries.Users;
using Abcloudz.WebAPI.Dto;
using Abcloudz.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))] 
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest user)
        {
            var command = new CreateUserCommand(user);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Users([FromQuery] UserFilter filter)
        {
            var query = new GetUsersQuery(filter);
            var users = await _mediator.Send(query);

            return Ok(users);
        }
    }
}

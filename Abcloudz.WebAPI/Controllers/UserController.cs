using Abcloudz.WebAPI.Filters;
using Abcloudz.WebAPI.Models;
using Abcloudz.WebAPI.Repositories;
using Abcloudz.WebAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))] 
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok();
        }


        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest user)
        {
            var userModel = new UserModel
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password
            };

            await _userRepository.AddAsync(userModel);
            return Ok();
        }

        [HttpGet]
        [Route("users")]
        public List<UserViewModel> Users()
        {
            var users = _userRepository.GetUsers();
            var response = _mapper.Map<List<UserViewModel>>(users);

            return response;
        }
    }
}

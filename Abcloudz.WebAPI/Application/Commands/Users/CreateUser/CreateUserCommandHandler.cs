using Abcloudz.DAL.Interfaces;
using Abcloudz.WebAPI.Dto;
using Abcloudz.WebAPI.Models;
using MediatR;

namespace Abcloudz.WebAPI.Application.Commands.Users.CreateUser
{
    public record CreateUserCommand(CreateUserRequest User) : IRequest;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userModel = new UserModel
            {
                Email = request.User.Email,
                Name = request.User.Name,
                Password = request.User.Password
            };

            await _userRepository.AddAsync(userModel);
        }
    }

}

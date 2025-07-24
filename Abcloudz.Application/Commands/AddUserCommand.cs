using Abcloudz.Application.Domain;

namespace Abcloudz.Application.Commands;

public class AddUserCommand(IRepository<User> userRepository)
{
    public Task Handle(AddUserDto userDto)
    {
        return userRepository.AddUser(
            new User { Name = userDto.Name, Email = userDto.Email, Password = userDto.Password });
    }
}
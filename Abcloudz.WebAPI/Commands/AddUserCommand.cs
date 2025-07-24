using Abcloudz.WebAPI.Domain;
using Abcloudz.WebAPI.Storage;

namespace Abcloudz.WebAPI.Commands;

public class AddUserCommand(UserRepository userRepository)
{
    public Task Handle(AddUserDto userDto)
    {
        return userRepository.AddUser(
            new User { Name = userDto.Name, Email = userDto.Email, Password = userDto.Password });
    }
}
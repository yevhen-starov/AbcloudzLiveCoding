using Abcloudz.WebAPI.Domain;
using Abcloudz.WebAPI.Storage;

namespace Abcloudz.WebAPI.Commands;

public class AddUserCommand(UserRepository userRepository)
{
    public void Handle(AddUserDto userDto)
    {
        userRepository.AddUser(new User { Name = userDto.Name, Email = userDto.Email, Password = userDto.Password });
    }
}
using Abcloudz.WebAPI.Storage;

namespace Abcloudz.WebAPI.Queries;

public record UserInfoDto(string Name, string Email);

public class GetUsersQuery(UserRepository userRepository)
{
    public IEnumerable<UserInfoDto> Handle()
    {
        return userRepository.GetUsers().Select(user => new UserInfoDto(user.Name, user.Email));
    }
}

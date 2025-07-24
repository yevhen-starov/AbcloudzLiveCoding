using Abcloudz.WebAPI.Storage;

namespace Abcloudz.WebAPI.Queries;

public class GetUsersQuery(UserRepository userRepository)
{
    public IEnumerable<UserInfoDto> Handle(UserInfoFilterModel filterModel)
    {
        var users = userRepository.GetUsers();
        if (filterModel.Email != null)
        {
            users = users.Where(x => x.Email.Contains(filterModel.Email));
        }
            
        return users.Skip(filterModel.GetSkipRecordsCount())
            .Take(filterModel.PageSize)
            .Select(user => new UserInfoDto(user.Name, user.Email));
    }
}

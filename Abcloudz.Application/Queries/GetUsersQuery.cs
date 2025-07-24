using Abcloudz.Application.Domain;

namespace Abcloudz.Application.Queries;

public class GetUsersQuery(IRepository<User> userRepository)
{
    public async Task<IEnumerable<UserInfoDto>> Handle(UserInfoFilterModel filterModel)
    {
        var users = await userRepository.GetUsers();
        if (filterModel.Email != null)
        {
            users = users.Where(x => x.Email.Contains(filterModel.Email)).ToList();
        }
            
        return users.Skip(filterModel.GetSkipRecordsCount())
            .Take(filterModel.PageSize)
            .Select(user => new UserInfoDto(user.Name, user.Email));
    }
}

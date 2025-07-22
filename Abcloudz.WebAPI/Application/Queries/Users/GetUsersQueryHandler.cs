using Abcloudz.DAL.Interfaces;
using Abcloudz.WebAPI.Dto;
using Abcloudz.WebAPI.ViewModels;
using AutoMapper;
using MediatR;

namespace Abcloudz.WebAPI.Application.Queries.Users
{
    public record GetUsersQuery(UserFilter Filter) : IRequest<List<UserViewModel>>;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync(request.Filter.PageNumber, request.Filter.PageSize, request.Filter.Search);

            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}

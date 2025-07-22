using Abcloudz.WebAPI.Models;
using Abcloudz.WebAPI.ViewModels;
using AutoMapper;

namespace Abcloudz.WebAPI.Profilers
{
    public class UserProfiler : Profile
    {
        public UserProfiler()
        {
            CreateMap<UserModel, UserViewModel>();
        }
    }
}

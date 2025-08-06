using Abcloudz.WebAPI.DTOs;
using Abcloudz.WebAPI.Models;

namespace Abcloudz.WebAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAllAsync(PaginationModel pagination);
    }
}

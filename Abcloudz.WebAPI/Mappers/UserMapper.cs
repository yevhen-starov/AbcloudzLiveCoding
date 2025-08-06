using Abcloudz.WebAPI.DTOs;
using Abcloudz.WebAPI.Entities;
using Abcloudz.WebAPI.Models;

namespace Abcloudz.WebAPI.Mappers
{
    public static class UserMapper
    {
        public static UserDTO MapToDto(this CreateUserModel createUserModel)
        {
            return new UserDTO
            {
                Name = createUserModel.UserName,
                Email = createUserModel.Email,
            };
        }

        public static DBUser MapToDB(this UserDTO userDTO)
        {
            return new DBUser
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
            };
        }

        public static UserDTO MapToDto(this DBUser userDb)
        {
            return new UserDTO
            {
               Id = userDb.Id,
               Name = userDb.Name,
               Email = userDb.Email,
            };
        }
    }
}

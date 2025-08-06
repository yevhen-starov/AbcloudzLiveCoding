using Abcloudz.WebAPI.DTOs;
using Abcloudz.WebAPI.Interfaces;
using Abcloudz.WebAPI.Mappers;
using Abcloudz.WebAPI.Models;
using FluentValidation;

namespace Abcloudz.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserDTO> _validator;

        public UserService(
            IUserRepository userRepository, 
            IValidator<UserDTO> validator
            ) 
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            var validationResult = _validator.Validate(userDTO);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)), nameof(userDTO));
            }

            var result = await _userRepository.CreateAsync(userDTO.MapToDB());

            return result.MapToDto();
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync(PaginationModel pagination)
        {
            var result = await _userRepository.GetAllAsync(pagination);

            return result.Select(x => x.MapToDto());
        }
    }
}

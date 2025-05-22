using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;
using System.Net;

namespace Projeto_Aplicado_II_API.Services
{
    public class UserService(MainDbContext db, IUserRepository userRepository, AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly AuthService _authService = authService;

        public async ValueTask<UserDto> GetByIdAsync(uint id)
        {
            var user = await _userRepository.GetByIdThrowsIfNullAsync(id);

            return UserDto.FromUser(user);
        }

        public async Task<UserDto> UpdateAsync(uint id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdThrowsIfNullAsync(id);

            user.UpdateFromDto(dto);

            await _db.ExecuteInTrasactionAsync(() =>
            {
                _userRepository.Update(user);
            });

            return UserDto.FromUser(user);
        }

        public async Task<UserDto> DeleteAsync(uint id)
        {
            var user = await _userRepository.GetByIdThrowsIfNullAsync(id);

            return await Delete(user);
        }

        public async Task<UserDto> Delete(User user)
        {
            var loggedUser = await _authService.GetLoggedUser();

            if ((loggedUser?.Id ?? 0) == user.Id)
            {
                throw new BusinessException("You cannot delete your own user.", HttpStatusCode.Forbidden);
            }

            await _db.ExecuteInTrasactionAsync(() =>
            {
                _userRepository.Remove(user);
            });

            return UserDto.FromUser(user);
        }
    }
}

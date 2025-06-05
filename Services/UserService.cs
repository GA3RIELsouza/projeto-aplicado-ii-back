using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;
using System.Net;

namespace Projeto_Aplicado_II_API.Services
{
    public class UserService(MainDbContext db,
        IUserRepository userRepository,
        IUserBranchRepository userBranchRepository,
        AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserBranchRepository _userBranchRepository = userBranchRepository;
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

            await _db.RunInTransactionAsync(() =>
            {
                _userRepository.Update(user);
            });

            return UserDto.FromUser(user);
        }

        public async Task<UserDto> DeleteAsync(uint id)
        {
            var user = await _userRepository.GetByIdThrowsIfNullAsync(id);

            var loggedUser = await _authService.GetLoggedUserAsync();

            if (loggedUser.Id == user.Id)
            {
                throw new BusinessException("Não é possível excluir seu próprio usuário.", HttpStatusCode.Forbidden);
            }

            await _db.RunInTransactionAsync(() =>
            {
                _userRepository.Remove(user);
            });

            return UserDto.FromUser(user);
        }

        public async Task<List<UserBranchesDto>> GetUserBranches(uint? userId = null)
        {
            var user = userId.HasValue
                ? await _userRepository.GetByIdIncludesThrowsIfNullAsync(userId.Value)
                : await _authService.GetLoggedUserAsync();

            var response = await _userBranchRepository.GetUsersBranches(user);

            return response;
        }
    }
}

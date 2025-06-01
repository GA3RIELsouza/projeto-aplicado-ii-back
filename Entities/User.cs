using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities.Base;
using Projeto_Aplicado_II_API.Entities.Interfaces;
using Projeto_Aplicado_II_API.Infrastructure.Extensions;

namespace Projeto_Aplicado_II_API.Entities
{
    public class User : EntityBase, IActivatable
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [32];
        public byte[] PasswordSaltHash { get; set; } = [16];
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<UserBranch>? UserBranches { get; set; }

        public static User FromRegisterDto(RegisterDto dto)
        {
            (var passwordHash, var passwordSaltHash) = dto.Password.HashPassword();

            return new()
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash,
                PasswordSaltHash = passwordSaltHash
            };
        }

        public void UpdateFromDto(UpdateUserDto dto) => Name = string.IsNullOrWhiteSpace(dto.Name) ? Name : dto.Name;
    }
}

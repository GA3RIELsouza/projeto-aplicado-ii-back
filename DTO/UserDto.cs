using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class UserDto
    {
        public uint Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public DateTime InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static UserDto FromUser(User user)
        {
            return new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                InsertedAt = user.InsertedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; } = String.Empty;
    }
}

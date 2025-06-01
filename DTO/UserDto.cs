using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.DTO
{
    public class UserDto
    {
        public uint Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public static UserDto FromUser(User user)
        {
            return new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };
        }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; } = string.Empty;
    }
}

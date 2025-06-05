using System.ComponentModel.DataAnnotations;

namespace Projeto_Aplicado_II_API.DTO
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDto
    {
        public uint UserId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}

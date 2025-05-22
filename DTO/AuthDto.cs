using System.ComponentModel.DataAnnotations;

namespace Projeto_Aplicado_II_API.DTO
{
    public class RegisterDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }

    public class LoginDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}

using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Infrastructure.Validations.Rules;
using FluentValidation;

namespace Projeto_Aplicado_II_API.Infrastructure.Validations.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name).NameRules();
            RuleFor(x => x.Email).EmailRules();
            RuleFor(x => x.Password).PasswordRules();
        }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).EmailRules();
            RuleFor(x => x.Password).PasswordRules();
        }
    }

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NameRules();
            RuleFor(x => x.Email).EmailRules();
        }
    }

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Name).NameRules();
        }
    }
}

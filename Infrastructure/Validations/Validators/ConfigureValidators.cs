using FluentValidation;

namespace Projeto_Aplicado_II_API.Infrastructure.Validations.Validators
{
    public static class ConfigureValidators
    {
        public static void AddValidators(this IServiceCollection validators)
        {
            validators.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
            validators.AddValidatorsFromAssemblyContaining<UserDtoValidator>();
        }
    }
}

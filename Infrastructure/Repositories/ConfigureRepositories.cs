using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public static class ConfigureServices
    {
        public static void AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

namespace Projeto_Aplicado_II_API.Services;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<AuthService>();
        services.AddScoped<ProductService>();
        services.AddScoped<BranchService>();
        services.AddScoped<CompanyService>();
        services.AddScoped<ProductCategoryService>();
    }
}

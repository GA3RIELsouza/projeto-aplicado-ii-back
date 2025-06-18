namespace Projeto_Aplicado_II_API.Services;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddScoped<UserService>();
        collection.AddScoped<AuthService>();
        collection.AddScoped<ProductService>();
        collection.AddScoped<BranchService>();
        collection.AddScoped<CompanyService>();
        collection.AddScoped<ProductCategoryService>();
        collection.AddScoped<UnityOfMeasureService>();
        collection.AddScoped<ProductInInventoryService>();
        collection.AddScoped<SupplierService>();
        collection.AddScoped<SupplierProductService>();
        collection.AddScoped<SaleService>();
    }
}

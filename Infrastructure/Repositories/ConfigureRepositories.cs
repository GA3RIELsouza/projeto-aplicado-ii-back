using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public static class ConfigureServices
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IBranchRepository, BranchRepository>();
            collection.AddScoped<IBranchSizeRepository, BranchSizeRepository>();
            collection.AddScoped<ICompanyRepository, CompanyRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();
            collection.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            collection.AddScoped<IProductInInventoryRepository, ProductInInventoryRepository>();
            collection.AddScoped<ISaleRepository, SaleRepository>();
            collection.AddScoped<ISaleItemRepository, SaleItemRepository>();
            collection.AddScoped<ISupplierRepository, SupplierRepository>();
            collection.AddScoped<ISupplierProductRepository, SupplierProductRepository>();
            collection.AddScoped<IUnityOfMeasureRepository, UnityOfMeasureRepository>();
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IUserBranchRepository, UserBranchRepository>();
        }
    }
}

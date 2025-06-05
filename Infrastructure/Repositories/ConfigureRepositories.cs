using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public static class ConfigureServices
    {
        public static void AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IBatchRepository, BatchRepository>();
            repositories.AddScoped<IBranchRepository, BranchRepository>();
            repositories.AddScoped<IBranchSizeRepository, BranchSizeRepository>();
            repositories.AddScoped<IClientRepository, ClientRepository>();
            repositories.AddScoped<ICompanyRepository, CompanyRepository>();
            repositories.AddScoped<IOrderRepository, OrderRepository>();
            repositories.AddScoped<IOrderItemRepository, OrderItemRepository>();
            repositories.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            repositories.AddScoped<IProductRepository, ProductRepository>();
            repositories.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            repositories.AddScoped<IProductInInventoryRepository, ProductInInventoryRepository>();
            repositories.AddScoped<ISaleRepository, SaleRepository>();
            repositories.AddScoped<ISaleItemRepository, SaleItemRepository>();
            repositories.AddScoped<ISupplierRepository, SupplierRepository>();
            repositories.AddScoped<ISupplierProductRepository, SupplierProductRepository>();
            repositories.AddScoped<IUnityOfMeasureRepository, UnityOfMeasureRepository>();
            repositories.AddScoped<IUserRepository, UserRepository>();
            repositories.AddScoped<IUserBranchRepository, UserBranchRepository>();
        }
    }
}

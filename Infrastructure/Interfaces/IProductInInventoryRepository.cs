using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface IProductInInventoryRepository : IBaseRepository<ProductInInventory>
    {
        Task<List<ProductInInventoryDto>> ListBranchInventoryAsync(uint branchId);
        Task<int> CountProductsInInventoryAsync(uint branchId, uint productId);
        Task<ProductInInventory[]> ListOldestProductsInInventory(uint branchId, uint productId, int quantity);
        Task<ProductInInventory[]> ListBySaleItemAsync(uint saleItemId);
        Task<ProductInInventory[]> ListBySaleAsync(uint saleId);
    }
}

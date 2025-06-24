using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface ISaleItemRepository : IBaseRepository<SaleItem>
    {
        Task<List<SaleItemDto>> ListSaleItemsAsync(uint branchId, uint saleId);
        Task<List<ProductMiniDto>> ListSaleItemsNotIncludedAsync(uint companyId, uint saleId);
        Task<SaleItem[]> ListByProductAsync(uint companyId, uint productId);
    }
}

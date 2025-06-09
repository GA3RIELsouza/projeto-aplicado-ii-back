using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface ISupplierProductRepository : IBaseRepository<SupplierProduct>
    {
        Task<List<SupplierProductDto>> ListSupplierProductsAsync(uint supplierId);
        Task<List<SupplierProductDto>> ListSupplierProductsDoesNotSellAsync(uint supplierId);
        Task<SupplierProduct?> GetBySupplierAndProductAsync(uint supplierId, uint productId);
        Task<List<SupplierMiniDto>> ListProductSuppliersAsync(uint productId);
    }
}

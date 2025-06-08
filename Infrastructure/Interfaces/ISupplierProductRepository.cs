using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface ISupplierProductRepository : IBaseRepository<SupplierProduct>
    {
        Task<List<ProductMiniDto>> ListSupplierProductsAsync(uint supplierId);
    }
}

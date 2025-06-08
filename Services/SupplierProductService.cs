using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class SupplierProductService(ISupplierProductRepository supplierProductRepository)
    {
        private readonly ISupplierProductRepository _supplierProductRepository = supplierProductRepository;

        public async Task<List<ProductMiniDto>> ListSupplierProductsAsync(uint supplierId)
        {
            var response = await _supplierProductRepository.ListSupplierProductsAsync(supplierId);

            return response;
        }
    }
}

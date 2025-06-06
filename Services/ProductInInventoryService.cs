using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductInInventoryService(IProductInInventoryRepository productInInventoryRepository)
    {
        private readonly IProductInInventoryRepository _productInInventoryRepository = productInInventoryRepository;

        public async Task<dynamic> ListBranchInventory(uint branchId)
        {
            return await _productInInventoryRepository.ListBranchInventory(branchId);
        }
    }
}

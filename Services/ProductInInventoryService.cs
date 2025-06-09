using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class ProductInInventoryService(MainDbContext db,
        IProductInInventoryRepository productInInventoryRepository,
        AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly IProductInInventoryRepository _productInInventoryRepository = productInInventoryRepository;
        private readonly AuthService _authService = authService;

        public async Task<List<ProductInInventoryDto>> ListBranchInventory(uint branchId)
        {
            return await _productInInventoryRepository.ListBranchInventoryAsync(branchId);
        }

        public async Task<int> AdjustProductInventoryAsync(AdjustProductInventoryDto dto)
        {
            dto.BranchId = _authService.GetLoggedBranchId();
            var productsInInventory = new ProductInInventory[dto.Quantity];

            for (int i = 0; i < dto.Quantity; i++)
            {
                productsInInventory[i] = new()
                {
                    BranchId = dto.BranchId,
                    ProductId = dto.ProductId,
                    SupplierId = dto.SupplierId,
                    ManufacturingDate = dto.ManufacturingDate
                };
            }

            await _db.RunInTransactionAsync(async () =>
            {
                await _productInInventoryRepository.AddRangeAsync(productsInInventory);
            });

            return await _productInInventoryRepository.CountProductsInInventoryAsync(dto.BranchId, dto.ProductId);
        }
    }
}

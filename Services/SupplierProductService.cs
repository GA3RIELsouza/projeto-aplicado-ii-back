using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Services
{
    public class SupplierProductService(MainDbContext db,
        ISupplierProductRepository supplierProductRepository,
        ISupplierRepository supplierRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly ISupplierProductRepository _supplierProductRepository = supplierProductRepository;
        private readonly ISupplierRepository _supplierRepository = supplierRepository;

        public async Task<CreateSupplierProductDto> GetByIdAsync(uint supplierId, uint productId)
        {
            var supplierProduct = await _supplierProductRepository.GetBySupplierAndProductAsync(supplierId, productId);

            return new()
            {
                SupplierId = supplierProduct!.SupplierId,
                ProductId = supplierProduct.ProductId,
                UnitaryPrice = supplierProduct.UnitaryPrice
            };
        }

        public async Task<uint> UpdateAsync(uint supplierId, uint productId, CreateSupplierProductDto dto)
        {
            var supplierProduct = await _supplierProductRepository.GetBySupplierAndProductAsync(supplierId, productId);

            supplierProduct!.UnitaryPrice = dto.UnitaryPrice;

            await _db.RunInTransactionAsync(() =>
            {
                _supplierProductRepository.Update(supplierProduct);
            });

            return supplierProduct.Id;
        }

        public async Task<uint> CreateSupplierProductAsync(CreateSupplierProductDto dto)
        {
            var supplierProduct = SupplierProduct.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _supplierProductRepository.AddAsync(supplierProduct);
            });

            return supplierProduct.Id;
        }

        public async Task<List<SupplierProductDto>> ListSupplierProductsAsync(uint supplierId)
        {
            var response = await _supplierProductRepository.ListSupplierProductsAsync(supplierId);

            return response;
        }

        public async Task<List<SupplierProductDto>> ListSupplierProductsDoesNotSellAsync(uint supplierId)
        {
            var response = await _supplierProductRepository.ListSupplierProductsDoesNotSellAsync(supplierId);

            return response;
        }

        public async Task DeleteSupplierProductAsync(uint supplierId, uint productId)
        {
            await _supplierRepository.ThrowIfNotExists(s => s.Id == supplierId);
            var supplierProduct = await _supplierProductRepository.GetBySupplierAndProductAsync(supplierId, productId) ?? throw new NotImplementedException();

            await _db.RunInTransactionAsync(() =>
            {
                _supplierProductRepository.Remove(supplierProduct);
            });
        }

        public async Task<List<SupplierMiniDto>> ListProductSuppliersAsync(uint productId)
        {
            var response = await _supplierProductRepository.ListProductSuppliersAsync(productId);

            return response;
        }
    }
}

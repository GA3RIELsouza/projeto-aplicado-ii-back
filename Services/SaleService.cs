using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;
using System.Net;

namespace Projeto_Aplicado_II_API.Services
{
    public class SaleService(MainDbContext db,
        ISaleRepository saleRepository,
        ISaleItemRepository saleItemRepository,
        IProductInInventoryRepository productInInventoryRepository,
        IBranchRepository branchRepository)
    {
        private readonly MainDbContext _db = db;
        private readonly ISaleRepository _saleRepository = saleRepository;
        private readonly ISaleItemRepository _saleItemRepository = saleItemRepository;
        private readonly IProductInInventoryRepository _productInInventoryRepository = productInInventoryRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;

        public async Task<uint> CreateSaleAsync(CreateSaleDto dto)
        {
            var sale = Sale.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _saleRepository.AddAsync(sale);
            });

            return sale.Id;
        }

        public async Task<List<SaleDto>> ListBranchSalesAsync(uint branchId)
        {
            var response = await _saleRepository.ListBranchSalesAsync(branchId);

            return response;
        }

        public async Task<List<SaleItemDto>> ListSaleItemsAsync(uint branchId, uint saleId)
        {
            var response = await _saleItemRepository.ListSaleItemsAsync(branchId, saleId);

            return response;
        }

        public async Task<List<ProductMiniDto>> ListSaleItemsNotIncludedAsync(uint branchId, uint saleId)
        {
            var branch = await _branchRepository.GetByIdThrowsIfNullAsync(branchId);

            var response = await _saleItemRepository.ListSaleItemsNotIncludedAsync(branch.CompanyId, saleId);

            return response;
        }

        public async Task<uint> AddItemToSaleAsync(CreateItemSaleDto dto)
        {
            var productsInInventory = await _productInInventoryRepository.ListOldestProductsInInventory(dto.BranchId, dto.ProductId, dto.Quantity);

            var productsInInventoryAmount = productsInInventory.Length;
            if (productsInInventoryAmount < dto.Quantity) throw new BusinessException($"Produtos insuficientes em estoque ({productsInInventoryAmount}).", HttpStatusCode.UnprocessableEntity);

            var saleItem = SaleItem.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                await _saleItemRepository.AddAsync(saleItem);
                await _db.SaveChangesAsync();

                for (int i = 0; i < productsInInventoryAmount; i++) productsInInventory[i].SaleItemId = saleItem.Id;
                _productInInventoryRepository.UpdateRange(productsInInventory);
            });

            return saleItem.Id;
        }

        public async Task DeleteSaleItemAsync(uint branchId, uint saleId, uint saleItemId)
        {
            await _branchRepository.ThrowIfNotExists(b => b.Id == branchId);
            await _saleRepository.ThrowIfNotExists(s => s.Id == saleId);
            var saleItem = await _saleItemRepository.GetByIdIncludesThrowsIfNullAsync(saleItemId);
            var productsInInventory = await _productInInventoryRepository.ListBySaleItemAsync(saleItemId);

            await _db.RunInTransactionAsync(() =>
            {
                _saleItemRepository.Remove(saleItem);
                for (int i = 0; i < productsInInventory.Length; i++) productsInInventory[i].SaleItemId = null;
                _productInInventoryRepository.UpdateRange(productsInInventory);
            });
        }

        public async Task DeleteSaleAsync(uint branchId, uint saleId)
        {
            await _branchRepository.ThrowIfNotExists(b => b.Id == branchId);
            var sale = await _saleRepository.GetByIdIncludesThrowsIfNullAsync(saleId);
            var productsInInventory = await _productInInventoryRepository.ListBySaleAsync(saleId);

            await _db.RunInTransactionAsync(() =>
            {
                _saleRepository.Remove(sale);
                for (int i = 0; i < productsInInventory.Length; i++) productsInInventory[i].SaleItemId = null;
                _productInInventoryRepository.UpdateRange(productsInInventory);
            });
        }
    }
}

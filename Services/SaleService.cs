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
        AuthService authService)
    {
        private readonly MainDbContext _db = db;
        private readonly ISaleRepository _saleRepository = saleRepository;
        private readonly ISaleItemRepository _saleItemRepository = saleItemRepository;
        private readonly IProductInInventoryRepository _productInInventoryRepository = productInInventoryRepository;
        private readonly AuthService _authService = authService;

        public async Task<CreateSaleDto> GetByIdAsync(uint id)
        {
            var sale = await _saleRepository.GetByIdThrowsIfNullAsync(id);

            return new()
            {
                SaleDateTime = sale.SaleDateTime
            };
        }

        public async Task<uint> UpdateAsync(uint id, CreateSaleDto dto)
        {
            var sale = await _saleRepository.GetByIdThrowsIfNullAsync(id);

            sale.SaleDateTime = dto.SaleDateTime;

            await _db.RunInTransactionAsync(() =>
            {
                _saleRepository.Update(sale);
            });

            return sale.Id;
        }

        public async Task<uint> CreateSaleAsync(CreateSaleDto dto)
        {
            var branchId = _authService.GetLoggedBranchId();
            dto.BranchId = branchId;
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

        public async Task<List<SaleItemDto>> ListSaleItemsAsync(uint saleId)
        {
            var branchId = _authService.GetLoggedBranchId();
            var response = await _saleItemRepository.ListSaleItemsAsync(branchId, saleId);

            return response;
        }

        public async Task<List<ProductMiniDto>> ListSaleItemsNotIncludedAsync(uint saleId)
        {
            var branch = await _authService.GetLoggedBranchAsync();
            var response = await _saleItemRepository.ListSaleItemsNotIncludedAsync(branch.CompanyId, saleId);

            return response;
        }

        public async Task<uint> AddItemToSaleAsync(CreateSaleItemDto dto, SaleItem? saleItem = null)
        {
            var add = saleItem is null;

            var productsInInventory = await _productInInventoryRepository.ListOldestProductsInInventory(_authService.GetLoggedBranchId(), dto.ProductId, dto.Quantity);

            var productsInInventoryAmount = productsInInventory.Length;
            if (productsInInventoryAmount < dto.Quantity) throw new BusinessException($"Produtos insuficientes em estoque ({productsInInventoryAmount}).", HttpStatusCode.UnprocessableEntity);

            saleItem ??= SaleItem.CreateFromDto(dto);

            await _db.RunInTransactionAsync(async () =>
            {
                if (add)
                {
                    await _saleItemRepository.AddAsync(saleItem);
                    await _db.SaveChangesAsync();
                    for (int i = 0; i < productsInInventoryAmount; i++) productsInInventory[i].SaleItemId = saleItem.Id;
                }
                else
                {
                    saleItem.Quantity += dto.Quantity;
                    _saleItemRepository.Update(saleItem);
                }

                _productInInventoryRepository.UpdateRange(productsInInventory);
            });

            return saleItem.Id;
        }

        public async Task<CreateSaleItemDto> GetSaleItemAsync(uint saleId, uint saleItemId)
        {
            await _saleRepository.ThrowIfNotExists(s => s.Id == saleId);
            var saleItem = await _saleItemRepository.GetByIdThrowsIfNullAsync(saleItemId);

            return new()
            {
                Quantity = saleItem.Quantity
            };
        }

        public async Task<uint> UpdateSaleItemAsync(uint saleId, uint saleItemId, CreateSaleItemDto dto)
        {
            await _saleRepository.ThrowIfNotExists(s => s.Id == saleId);
            var saleItem = await _saleItemRepository.GetByIdThrowsIfNullAsync(saleItemId);

            ProductInInventory[] productsInInventory = [];

            var add = dto.Quantity > saleItem.Quantity;

            for (int i = 0; i < productsInInventory.Length; i++) productsInInventory[i].SaleItemId = null;

            if (add)
            {
                dto.SaleId = saleId;
                dto.ProductId = saleItem.ProductId;
                dto.Quantity -= saleItem.Quantity;

                await AddItemToSaleAsync(dto, saleItem);
            }
            else
            {
                productsInInventory = await _productInInventoryRepository.ListBySaleAsync(saleId);
                productsInInventory = [.. productsInInventory.OrderByDescending(pii => pii.ManufacturingDate).Take(Math.Abs(dto.Quantity - saleItem.Quantity))];
                
                saleItem.Quantity = dto.Quantity;
            }

            await _db.RunInTransactionAsync(() =>
            {
                if (!add)
                {
                    _saleItemRepository.Update(saleItem);
                    _productInInventoryRepository.UpdateRange(productsInInventory);
                }
            });

            return saleItem.Id;
        }

        public async Task DeleteSaleItemAsync(uint saleId, uint saleItemId)
        {
            var branch = await _authService.GetLoggedBranchAsync();
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

        public async Task DeleteSaleAsync(uint saleId)
        {
            var branch = await _authService.GetLoggedBranchAsync();
            var sale = await _saleRepository.GetByIdThrowsIfNullAsync(saleId);
            var productsInInventory = await _productInInventoryRepository.ListBySaleAsync(saleId);

            for (int i = 0; i < productsInInventory.Length; i++) productsInInventory[i].SaleItemId = null;

            await _db.RunInTransactionAsync(() =>
            {
                _saleRepository.Remove(sale);
                _productInInventoryRepository.UpdateRange(productsInInventory);
            });
        }
    }
}

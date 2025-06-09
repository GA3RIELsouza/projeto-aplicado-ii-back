using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class ProductInInventoryRepository(MainDbContext db) : BaseRepository<ProductInInventory>(db), IProductInInventoryRepository
    {
        public async Task<List<ProductInInventoryDto>> ListBranchInventoryAsync(uint branchId)
        {
            return await _db.Products
                .Where(p => p.IsActive)
                .GroupJoin(
                    _db.ProductsInInventory,
                    p => p.Id,
                    pii => pii.ProductId,
                    (p, piins) => new ProductInInventoryDto
                    {
                        Product = new()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            ImageUrl = p.ImageUrl
                        },
                        MinimalInventoryQuantity = p.MinimalInventoryQuantity,
                        QuantityInInventory = piins.Count(pii => pii.BranchId == branchId && !pii.SaleItemId.HasValue)
                    }
                )
                .OrderBy(pii => pii.Product.Name)
                .ToListAsync();
        }

        public async Task<int> CountProductsInInventoryAsync(uint branchId, uint productId)
        {
            return await _db.ProductsInInventory
                .Where(pii => pii.BranchId == branchId && pii.ProductId == productId)
                .CountAsync();
        }

        public async Task<ProductInInventory[]> ListOldestProductsInInventory(uint branchId, uint productId, int quantity)
        {
            return await _db.ProductsInInventory
                .Where(pii => pii.BranchId == branchId && pii.ProductId == productId)
                .OrderBy(pii => pii.CreatedAt)
                .Take(quantity)
                .ToArrayAsync();
        }

        public async Task<ProductInInventory[]> ListBySaleItemAsync(uint saleItemId)
        {
            return await _db.ProductsInInventory
                .Where(pii => pii.SaleItemId == saleItemId)
                .ToArrayAsync();
        }

        public async Task<ProductInInventory[]> ListBySaleAsync(uint saleId)
        {
            return await _db.ProductsInInventory
                .Include(pii => pii.SaleItem)
                .Where(pii => pii.SaleItem!.SaleId == saleId)
                .ToArrayAsync();
        }
    }
}

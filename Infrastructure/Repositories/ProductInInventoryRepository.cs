using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class ProductInInventoryRepository(MainDbContext db) : BaseRepository<ProductInInventory>(db), IProductInInventoryRepository
    {
        public async Task<List<ProductInInventoryDto>> ListBranchInventory(uint branchId)
        {
            return await _db.Products
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
                        QuantityInInventory = piins.Count(),
                        UpdatedAt = (piins.Max(i => i.UpdatedAt) > piins.Max(i => i.CreatedAt) ? piins.Max(i => i.UpdatedAt) : piins.Max(i => i.CreatedAt)) ?? DateTime.Now
                    }
                )
                .ToListAsync();
        }
    }
}

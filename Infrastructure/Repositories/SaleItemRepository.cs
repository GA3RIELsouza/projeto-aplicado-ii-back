using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class SaleItemRepository(MainDbContext db) : BaseRepository<SaleItem>(db), ISaleItemRepository
    {
        public async Task<List<SaleItemDto>> ListSaleItemsAsync(uint branchId, uint saleId)
        {
            return await _db.SaleItems
                .Include(si => si.Sale)
                .Include(si => si.Product)
                    .ThenInclude(p => p.SupplierProducts)
                .Where(si => si.Product!.IsActive && si.Sale!.BranchId == branchId && si.SaleId == saleId)
                .Select(si => new SaleItemDto
                {
                    Id = si.Id,
                    Product = new()
                    {
                        Id = si.Product!.Id,
                        Name = si.Product.Name,
                        ImageUrl = si.Product.ImageUrl
                    },
                    Quantity = si.Quantity,
                    ItemSaleTotal = si.Quantity * si.Product!.UnitarySellingPrice
                })
                .ToListAsync();
        }

        public async Task<List<ProductMiniDto>> ListSaleItemsNotIncludedAsync(uint companyId, uint saleId)
        {
            return await _db.Products
                .Include(p => p.SaleItems)
                .Where(p => p.IsActive && p.CompanyId == companyId && !p.SaleItems!.Where(si => si.SaleId == saleId).Select(si => si.ProductId).ToList().Contains(p.Id))
                .Select(p => new ProductMiniDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }
    }
}

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
                .Where(si => si.Sale!.BranchId == branchId && si.SaleId == saleId)
                .Select(si => new SaleItemDto
                {
                    Id = si.Id,
                    Product = new()
                    {
                        Id = si.Product!.Id,
                        Name = si.Product.Name,
                        ImageBase64 = si.Product.ImageBase64
                    },
                    Quantity = si.Quantity,
                    ItemSaleTotal = si.Quantity * si.Product!.UnitarySellingPrice
                })
                .OrderBy(si => si.Product.Name)
                .ToListAsync();
        }

        public async Task<List<ProductMiniDto>> ListSaleItemsNotIncludedAsync(uint companyId, uint saleId)
        {
            return await _db.Products
                .Include(p => p.SaleItems)
                .Where(p => p.IsActive && p.CompanyId == companyId && !p.SaleItems!.Where(si => si.SaleId == saleId).Select(si => si.ProductId).Contains(p.Id))
                .Select(p => new ProductMiniDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<SaleItem[]> ListByProductAsync(uint companyId, uint productId)
        {
            return await _db.SaleItems
                .Include(si => si.Product)
                .Where(si => si.Product!.CompanyId == companyId && si.ProductId == productId)
                .ToArrayAsync();
        }
    }
}

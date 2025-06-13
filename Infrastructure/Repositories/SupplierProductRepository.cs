using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class SupplierProductRepository(MainDbContext db) : BaseRepository<SupplierProduct>(db), ISupplierProductRepository
    {
        public async Task<List<SupplierProductDto>> ListSupplierProductsAsync(uint supplierId)
        {
            return await _db.SupplierProducts
                .Include(sp => sp.Supplier)
                .Include(sp => sp.Product)
                .Where(sp => sp.SupplierId == supplierId && sp.Supplier!.IsActive && sp.Product!.IsActive)
                .Select(sp => new SupplierProductDto
                {
                    Id = sp.ProductId,
                    Name = sp.Product!.Name,
                    ImageUrl = sp.Product.ImageUrl,
                    UnitaryPrice = sp.UnitaryPrice
                })
                .OrderBy(sp => sp.Name)
                .ToListAsync();
        }

        public async Task<List<SupplierProductDto>> ListSupplierProductsDoesNotSellAsync(uint supplierId)
        {
            return await _db.Products
                .Include(p => p.SupplierProducts!)
                    .ThenInclude(sp => sp.Supplier)
                .Where(p => p.IsActive && !p.SupplierProducts!.Where(sp => sp.Supplier!.IsActive && sp.SupplierId == supplierId && sp.ProductId == p.Id).Any())
                .Select(p => new SupplierProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    UnitaryPrice = 0
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<SupplierProduct?> GetBySupplierAndProductAsync(uint supplierId, uint productId)
        {
            return await _db.SupplierProducts
                .Include(sp => sp.Supplier)
                .Include(sp => sp.Product)
                .Where(sp => sp.SupplierId == supplierId && sp.ProductId == productId && sp.Supplier!.IsActive && sp.Product!.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SupplierMiniDto>> ListProductSuppliersAsync(uint productId)
        {
            return await _db.SupplierProducts
                .Include(sp => sp.Supplier)
                .Include(sp => sp.Product)
                .Where(sp => sp.ProductId == productId && sp.Supplier!.IsActive && sp.Product!.IsActive)
                .Select(sp => new SupplierMiniDto
                {
                    Id = sp.SupplierId,
                    BusinessName = sp.Supplier!.BusinessName
                })
                .ToListAsync();
        }
    }
}

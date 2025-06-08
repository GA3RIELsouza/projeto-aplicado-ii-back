using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class SupplierProductRepository(MainDbContext db) : BaseRepository<SupplierProduct>(db), ISupplierProductRepository
    {
        public async Task<List<ProductMiniDto>> ListSupplierProductsAsync(uint supplierId)
        {
            return await _db.SupplierProducts
                .Include(sp => sp.Product)
                .Where(sp => sp.SupplierId == supplierId)
                .Select(sp => new ProductMiniDto
                {
                    Id = sp.ProductId,
                    Name = sp.Product!.Name,
                    ImageUrl = sp.Product.ImageUrl
                })
                .ToListAsync();
        }
    }
}

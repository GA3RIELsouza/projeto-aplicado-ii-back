using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class ProductRepository(MainDbContext db) : BaseRepository<Product>(db), IProductRepository
    {
        public async Task<List<CompanyProductDto>> ListCompanyProducts(uint companyId)
        {
            return await _db.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.UnityOfMeasure)
                .Where(p => p.CompanyId == companyId)
                .Select(p => new CompanyProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Ean13BarCode = p.Ean13BarCode,
                    ImageBase64 = p.ImageBase64,
                    ProductCategory = new() { Description = p.ProductCategory!.Description },
                    UnitarySellingPrice = p.UnitarySellingPrice,
                    UnityOfMeasure = new() { Description = p.UnityOfMeasure!.Description, Symbol = p.UnityOfMeasure.Symbol },
                    MinimalInventoryQuantity = p.MinimalInventoryQuantity,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .OrderByDescending(p => p.IsActive)
                .ThenBy(p => p.Name)
                .ToListAsync();
        }
    }
 }

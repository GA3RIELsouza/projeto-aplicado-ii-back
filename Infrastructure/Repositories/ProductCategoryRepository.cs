using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class ProductCategoryRepository(MainDbContext db) : BaseRepository<ProductCategory>(db), IProductCategoryRepository
    {
        public async Task<List<ProductCategoryDto>> ListProductCategoriesByCompanyAsync(uint companyId)
        {
            return await _db.ProductCategories
                .Where(pc => pc.CompanyId == companyId)
                .Select(pc => new ProductCategoryDto
                {
                    Id = pc.Id,
                    Description = pc.Description
                })
                .ToListAsync();
        }
    }
}

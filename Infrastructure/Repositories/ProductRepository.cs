using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class ProductRepository(MainDbContext db) : BaseRepository<Product>(db), IProductRepository
    {
        public async Task ListCompanyProducts(uint companyId)
        {
            return await _dbSet
                .Where(p => p.CompanyId == companyId)
                .Select(p => new
                {

                })
                .ToListAsync();
        }
    }
 }

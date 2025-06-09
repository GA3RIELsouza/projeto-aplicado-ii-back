using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class SaleRepository(MainDbContext db) : BaseRepository<Sale>(db), ISaleRepository
    {
        public async Task<List<SaleDto>> ListBranchSalesAsync(uint branchId)
        {
            return await _db.Sales
                .Include(s => s.SaleItems!)
                    .ThenInclude(si => si.Product)
                        .ThenInclude(p => p!.SupplierProducts)
                .Where(s => s.BranchId == branchId)
                .Select(s => new SaleDto
                {
                    Id = s.Id,
                    SaleDateTime = s.SaleDateTime,
                    SaleTotal = s.SaleItems!
                        .Sum(si => si.Quantity * si.Product!.UnitarySellingPrice)
                })
                .ToListAsync();
        }
    }
}

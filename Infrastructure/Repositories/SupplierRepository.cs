using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class SupplierRepository(MainDbContext db) : BaseRepository<Supplier>(db), ISupplierRepository
    {
        public async Task<List<SupplierDto>> ListCompanySuppliers(uint companyId)
        {
            return await _db.Suppliers
                .Where(s => s.CompanyId == companyId)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    BusinessName = s.BusinessName,
                    TaxId = s.TaxId,
                    Address = $"{s.Street}, {s.Number} - {s.Neighborhood}, {s.City} - {s.State}, {s.Country}",
                    Email = s.Email,
                    Phone = s.Phone,
                    IsActive = s.IsActive,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                })
                .OrderByDescending(s => s.IsActive)
                .ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class UnityOfMeasureRepository(MainDbContext db) : BaseRepository<UnityOfMeasure>(db), IUnityOfMeasureRepository
    {
        public async Task<List<UnityOfMeasureDto>> ListUnitiesOfMeasure()
        {
            return await _db.UnitiesOfMeasure
                .Select(uom => new UnityOfMeasureDto
                {
                    Id = uom.Id,
                    Description = uom.Description,
                    Symbol = uom.Symbol
                })
                .ToListAsync();
        }
    }
}

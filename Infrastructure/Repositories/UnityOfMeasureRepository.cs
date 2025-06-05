using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class UnityOfMeasureRepository(MainDbContext db) : BaseRepository<UnityOfMeasure>(db), IUnityOfMeasureRepository
    {
    }
}

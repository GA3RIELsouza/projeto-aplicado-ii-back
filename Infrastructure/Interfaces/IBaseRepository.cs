using System.Linq.Expressions;
using Projeto_Aplicado_II_API.Entities.Base;

namespace Projeto_Aplicado_II_API.Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(params TEntity[] entities);
        Task ThrowIfNotExists(Expression<Func<TEntity, bool>> where);
        ValueTask<TEntity?> GetByIdAsync(uint id);
        ValueTask<TEntity> GetByIdThrowsIfNullAsync(uint id, string? message = null);
        Task<TEntity?> GetByIdIncludesAsync(uint id, params Expression<Func<TEntity, dynamic?>>[] includes);
        Task<TEntity> GetByIdIncludesThrowsIfNullAsync(uint id, string? message = null, params Expression<Func<TEntity, dynamic?>>[] includes);
        void Update(TEntity entity);
        void UpdateRange(params TEntity[] entities);
        void Remove(TEntity entity);
        void RemoveRange(params TEntity[] entities);
    }
}

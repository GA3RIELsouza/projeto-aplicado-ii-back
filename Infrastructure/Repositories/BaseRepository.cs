using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Projeto_Aplicado_II_API.Entities.Base;
using System.Linq.Expressions;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity>(MainDbContext db) : IBaseRepository<TEntity>, IDisposable where TEntity : EntityBase
    {
        private readonly string entityName = typeof(TEntity).Name;

        private protected readonly MainDbContext _db = db;
        private readonly DbSet<TEntity> _dbSet = db.Set<TEntity>();
        
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(params TEntity[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task ThrowIfNotExists(Expression<Func<TEntity, bool>> where)
        {
            var exists = await _dbSet.AnyAsync(where);

            if (!exists)
            {
                throw new BusinessException($"Não foi possível encontrar {entityName}.", HttpStatusCode.NotFound);
            }
        }

        public async ValueTask<TEntity?> GetByIdAsync(uint id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async ValueTask<TEntity> GetByIdThrowsIfNullAsync(uint id, string? message = null)
        {
            message ??= $"Não foi possível encontrar {entityName}.";

            return await GetByIdAsync(id) ?? throw new BusinessException(message, HttpStatusCode.NotFound);
        }

        public async Task<TEntity?> GetByIdIncludesAsync(uint id, params Expression<Func<TEntity, dynamic?>>[] includes)
        {
            var query = _dbSet.Where(x => x.Id == id);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdIncludesThrowsIfNullAsync(uint id, string? message = null, params Expression<Func<TEntity, dynamic?>>[] includes)
        {
            message ??= $"No {entityName} with ID {id} could be found.";

            return await GetByIdIncludesAsync(id, includes) ?? throw new BusinessException(message, HttpStatusCode.NotFound);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(params TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using NewsApi.DataLayer.Entities.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.DataLayer.Repositories
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntitiesQuery();
        Task<TEntity> GetEntityByIdAsync(long id);
        Task CreateEntityAsync(TEntity entity);
        void UpdateEntity(TEntity entity);
        bool RemoveEntity(TEntity entity);
        Task<bool> RemoveEntityAsync(long id);
        Task SaveChangesAsync();
    }
}

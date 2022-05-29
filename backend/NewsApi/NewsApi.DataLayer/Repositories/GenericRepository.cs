using Microsoft.EntityFrameworkCore;
using NewsApi.DataLayer.Context;
using NewsApi.DataLayer.Entities.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.DataLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region constructor

        private NewsDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(NewsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region get entities query

        public IQueryable<TEntity> GetEntitiesQuery()
        {
            return _dbSet.AsQueryable();
        }

        #endregion

        #region get entity by id

        public async Task<TEntity> GetEntityByIdAsync(long id)
        {
            return await _dbSet.SingleOrDefaultAsync(s => s.Id == id);
        }

        #endregion

        #region create entity

        public async Task CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        #endregion

        #region edit entity

        public void UpdateEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        #endregion

        #region remove

        public bool RemoveEntity(TEntity entity)
        {
            if (entity != null)
            {
                entity.IsDelete = true;
                UpdateEntity(entity);
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveEntityAsync(long id)
        {
            var entity = await GetEntityByIdAsync(id);
            if (entity != null)
            {
                RemoveEntity(entity);
                return true;
            }

            return false;
        }

        #endregion

        #region save changes

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region dispos

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        #endregion
    }
}

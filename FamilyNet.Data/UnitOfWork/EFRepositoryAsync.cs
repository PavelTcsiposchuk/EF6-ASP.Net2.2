using FamilyNet.Models.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyNet.Data.Interfaces;

namespace FamilyNet.Data.UnitOfWork
{
    public class EFRepositoryAsync<TEntity> : IAsyncRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public EFRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Get all instances TEntity from the database without tracking their changes.(it will work faster)
        /// </summary>
        /// <returns>IQueryable<TEntity></returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public async Task Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

using Back.Data;
using Back.Data.Entities;
using BackV2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackV2.Data
{
    public abstract class EFCoreRepository<TEntity,TContext>: IRepository<TEntity>
        where TContext: DbContext
        where TEntity : class, IEntity
    {
        protected readonly TContext dbContext;

        public EFCoreRepository(TContext dbcontext) {this.dbContext = dbcontext;}

        public async Task<List<TEntity>> GetAllAsync() => await dbContext.Set<TEntity>().ToListAsync();
        
        public async Task<TEntity> GetAsync(int id) => await dbContext.Set<TEntity>().FindAsync(id);
        
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity;
        }
        
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }
        
        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null) return null;

            dbContext.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}

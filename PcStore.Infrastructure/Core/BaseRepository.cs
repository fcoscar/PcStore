using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PcStore.Domain.Repository;
using PcStore.Infrastructure.Context;

namespace PcStore.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PcStoreContext context;
        private readonly DbSet<TEntity> myDbSet;

        public BaseRepository(PcStoreContext context)
        {
            this.context = context;
            myDbSet = this.context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await myDbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityById(int id)
        {
            return await myDbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Save(TEntity entity)
        {
            await myDbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task Save(params TEntity[] entities)
        {
            await myDbSet.AddRangeAsync(entities);
        }

        public virtual async Task Update(TEntity entity)
        {
            myDbSet.Update(entity);
        }

        public virtual async Task Update(params TEntity[] entities)
        {
            myDbSet.UpdateRange(entities);
        }

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
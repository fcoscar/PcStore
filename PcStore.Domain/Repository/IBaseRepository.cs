using System.Collections.Generic;
using System.Threading.Tasks;

namespace PcStore.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetEntityById(int id);
        Task<TEntity> Save(TEntity entity);
        Task Save(params TEntity[] entities);
        Task Update(TEntity entity);
        Task Update(params TEntity[] entities);
        Task SaveChanges();
    }
}
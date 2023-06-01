using System.Threading.Tasks;
using PcStore.Domain.Entity;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Core;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductoRepository
    {
        private readonly PcStoreContext context;

        public ProductRepository(PcStoreContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<Product> Save(Product entity)
        {
            await base.Save(entity);
            await base.SaveChanges();
            return entity;
        }
    }
}
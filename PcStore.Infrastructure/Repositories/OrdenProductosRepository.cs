using System.Threading.Tasks;
using PcStore.Domain.Entity;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Core;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Infrastructure.Repositories
{
    public class OrdenProductosRepository : BaseRepository<OrdenProductos>, IOrdenProductosRespository
    {
        private readonly PcStoreContext context;

        public OrdenProductosRepository(PcStoreContext context) : base(context)
        {
            this.context = context;
        }
        public override async Task Save(OrdenProductos[] entity)
        {
            await base.Save(entity);
            await base.SaveChanges();
        }
    }
}
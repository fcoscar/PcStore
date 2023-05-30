using PcStore.Domain.Entity;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Core;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Infrastructure.Repositories
{
    public class OrdenRepository : BaseRepository<Orden>, IOrdenRepository
    {
        private readonly PcStoreContext context;

        public OrdenRepository(PcStoreContext context) : base(context)
        {
            this.context = context;
        }
    }
}
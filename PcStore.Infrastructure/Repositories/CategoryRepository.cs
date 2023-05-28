using PcStore.Domain.Entity;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Core;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly PcStoreContext context;
        public CategoryRepository(PcStoreContext context) : base(context)
        {
            this.context = context;
        }
    }
}
using PcStore.Domain.Entity;
using PcStore.Infrastructure.Context;
using PcStore.Infrastructure.Core;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PcStoreContext context;

        public UserRepository(PcStoreContext context) : base(context)
        {
            this.context = context;
        }
    }
}
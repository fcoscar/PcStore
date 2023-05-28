using PcStore.Domain.Entity;
using PcStore.Domain.Repository;

namespace PcStore.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //metodos exclusivos para Usuarios
    }
}
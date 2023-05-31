using System.Threading.Tasks;
using PcStore.Domain.Entity;
using PcStore.Domain.Repository;

namespace PcStore.Infrastructure.Interfaces
{
    public interface IOrdenRepository : IBaseRepository<Orden>
    {
        //metodos exclusivos para Ordenes
    }
}
using PcStore.Domain.Entity;
using PcStore.Domain.Repository;

namespace PcStore.Infrastructure.Interfaces
{
    public interface IOrdenProductosRespository : IBaseRepository<OrdenProductos>
    {
        //metodos exclusivos para Productos de Ordenes
    }
}
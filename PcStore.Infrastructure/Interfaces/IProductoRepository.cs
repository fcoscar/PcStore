using PcStore.Domain.Entity;
using PcStore.Domain.Repository;

namespace PcStore.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Product>
    {
        //metodos exclusivos para Productos
    }
}
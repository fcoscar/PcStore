using PcStore.Domain.Entity;
using PcStore.Domain.Repository;

namespace PcStore.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        //metodos exclusivos para Categorias
    }
}
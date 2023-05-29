using System.Threading.Tasks;
using PcStore.Application.Core;

namespace PcStore.Application.Contract
{

    public interface IProductService
    {
        public Task<ServiceResult> GetProducts();

    }
}
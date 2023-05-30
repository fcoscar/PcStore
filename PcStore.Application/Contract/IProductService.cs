using PcStore.Application.Core;

namespace PcStore.Application.Contract;

public interface IProductService
{
    public Task<ServiceResult> GetProducts();
    public Task<ServiceResult> GetProductById(int id);
    public Task<ServiceResult> GetProductByCategory(int categoryId);
}
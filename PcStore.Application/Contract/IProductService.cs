using PcStore.Application.Core;
using PcStore.Application.Dtos.Product;

namespace PcStore.Application.Contract;

public interface IProductService
{
    public Task<ServiceResult> GetProducts();
    public Task<ServiceResult> GetProductById(int id);
    public Task<ServiceResult> GetProductByCategory(int categoryId);
    public Task<ServiceResult> SaveProd(ProductAddDto productAddDto);
}
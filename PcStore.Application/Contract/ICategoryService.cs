using PcStore.Application.Core;

namespace PcStore.Application.Contract;

public interface ICategoryService
{
    public Task<ServiceResult> GetCategory();
    public Task<ServiceResult> GetCategoryById(int id);
}
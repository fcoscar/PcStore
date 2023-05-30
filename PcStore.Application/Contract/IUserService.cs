using PcStore.Application.Core;

namespace PcStore.Application.Contract;

public interface IUserService
{
    public Task<ServiceResult> GetUsers();
}
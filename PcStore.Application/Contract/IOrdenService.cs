using PcStore.Application.Core;
using PcStore.Application.Dtos.Orden;
using PcStore.Domain.Entity;

namespace PcStore.Application.Contract;

public interface IOrdenService
{
    public Task<ServiceResult> GetOrds();
    public Task<ServiceResult> GetOrdsById(int id);
    public Task<ServiceResult> Save(OrdenAddDto orden, List<OrdenProductAddDto> ordProds);
}
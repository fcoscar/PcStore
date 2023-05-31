using PcStore.Application.Dtos.Orden;

namespace PcStore.API;

public class RequestParams
{
    public OrdenAddDto Orden { get; set; }
    public List<OrdenProductAddDto> OrdenProductos { get; set; }
}
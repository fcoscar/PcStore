using PcStore.Domain.Entity;

namespace PcStore.Application.Dtos.Orden;

public class OrdenGetDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string ClienteName { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<OrdenProductos> OrdProd { get; set; }
}
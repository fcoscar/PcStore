namespace PcStore.Application.Dtos.Orden;

public class OrdenProductoGetDto
{
    public int Id { get; set; }
    public int OrdenId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioPorProducto { get; set; }
    public decimal TotalPorProducto { get; set; }
}
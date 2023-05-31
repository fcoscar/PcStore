using PcStore.Application.Dtos.Orden;
using PcStore.Domain.Entity;

namespace PcStore.Application.Extensions;

public static class OrderExtension
{
    public static Orden ConvertOrdenAddDtoToOrden(this OrdenAddDto ordenAddDto)
    {
        return new Orden()
        {
            ClienteName = ordenAddDto.ClientName,
            ClientId = ordenAddDto.ClientId,
            FechaCreacion = ordenAddDto.FechaCreacion,
            Eliminado = false,
            IdUsuarioCreacion = ordenAddDto.ClientId
        };
    }

    public static OrdenProductos ConvertOrdenProductAddToOrdenProduct(this OrdenProductAddDto ordenProductAddDto)
    {
        return new OrdenProductos()
        {
            //OrdenId = ordenProductAddDto.OrdenId,
            ProductId = ordenProductAddDto.ProductId,
            ProductName = ordenProductAddDto.ProductName,
            ProductDescription = ordenProductAddDto.ProductDescription,
            Cantidad = ordenProductAddDto.Cantidad,
            PrecioPorProducto = ordenProductAddDto.PrecioPorProducto
        };
    }
}
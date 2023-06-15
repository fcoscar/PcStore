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

    public static OrdenProductoGetDto ConvertOrdenProductToOrdenProductoGetDto(this OrdenProductos ordenProductos)
    {
        return new OrdenProductoGetDto()
        {
            //OrdenId = ordenProductAddDto.OrdenId,
            ProductId = ordenProductos.ProductId,
            ProductName = ordenProductos.ProductName,
            ProductDescription = ordenProductos.ProductDescription,
            Cantidad = ordenProductos.Cantidad,
            PrecioPorProducto = ordenProductos.PrecioPorProducto
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
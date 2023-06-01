using PcStore.Application.Dtos.Product;
using PcStore.Domain.Entity;

namespace PcStore.Application.Extensions;

public static class ProductExtension
{
    public static Product ConvertProductAddDtoToProduct(this ProductAddDto productAddDto)
    {
        return new Product()
        {
            Nombre = productAddDto.Nombre,
            Descripcion = productAddDto.Descripcion,
            CategoriaId = productAddDto.CategoriaId,
            Precio = productAddDto.Precio,
            Stock = productAddDto.Stock,
            ImgUrl = productAddDto.ImgUrl,
            FechaCreacion = productAddDto.FechaCreacion,
            IdUsuarioCreacion = productAddDto.IdUsuarioCreacion
        };
    }
}
using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Application.Dtos.Product;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Application.Services;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> logger;
    private readonly IProductoRepository productoRepository;

    public ProductService(IProductoRepository productoRepository, ILogger<ProductService> logger)
    {
        this.productoRepository = productoRepository;
        this.logger = logger;
    }

    public async Task<ServiceResult> GetProducts()
    {
        var result = new ServiceResult();
        try
        {
            result.Data = await GetProds();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo productos";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    private async Task<List<ProductGetDto>> GetProds()
    {
        var prodList = new List<ProductGetDto>();
        prodList = (from prod in await productoRepository.GetAll()
            select new ProductGetDto
            {
                Id = prod.Id,
                Nombre = prod.Nombre,
                Descripcion = prod.Descripcion,
                CategoriaId = prod.CategoriaId,
                Precio = prod.Precio,
                Stock = prod.Stock,
                ImgUrl = prod.ImgUrl,
                FechaCreacion = prod.FechaCreacion
            }).ToList();
        return prodList;
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Infrastructure.Interfaces;
using PcStore.Application.Dtos.Product;

namespace PcStore.Application.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductoRepository productoRepository;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductoRepository productoRepository, ILogger<ProductService> logger)
        {
            this.productoRepository = productoRepository;
            this.logger = logger;
        }

        public async Task<ServiceResult> GetProducts()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from prod in (await productoRepository.GetAll())
                    select new ProductGetDto()
                    {
                        Id = prod.Id,
                        Nombre = prod.Nombre,
                        Descripcion = prod.Descripcion,
                        CategoriaId = prod.CategoriaId,
                        Precio = prod.Precio,
                        Stock = prod.Stock,
                        ImgUrl = prod.ImgUrl,
                        FechaCreacion = prod.FechaCreacion
                    });
                result.Data = query;
            }
            catch (Exception e)
            {
                result.Message = "Error obteniendo productos";
                result.Success = false;
                logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
            }

            return result;
        }
    }
}
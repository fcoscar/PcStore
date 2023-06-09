﻿using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Application.Dtos.Product;
using PcStore.Application.Extensions;
using PcStore.Domain.Entity;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Application.Services;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> logger;
    private readonly IProductoRepository productoRepository;
    private readonly ICategoryRepository categoryRepository;

    public ProductService(IProductoRepository productoRepository, ILogger<ProductService> logger,
        ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
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

    public async Task<ServiceResult> GetProductById(int id)
    {
        var result = new ServiceResult();
        try
        {
            result.Data = (await GetProds(id:id)).FirstOrDefault();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo producto";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    public async Task<ServiceResult> GetProductByCategory(int categoryId)
    {
        var result = new ServiceResult();
        try
        {
            result.Data = await GetProds(categoryId:categoryId);
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo productos por categoria";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }
        
        return result;
    }

    public async Task<ServiceResult> SaveProd(ProductAddDto productAddDto)
    {
        var result = new ServiceResult();
        try
        {
            var newProd = productAddDto.ConvertProductAddDtoToProduct();
            await productoRepository.Save(newProd);
        }
        catch (Exception e)
        {
            result.Message = "Error gurdando productos";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }
        return result;
    }

    private async Task<List<ProductGetDto>> GetProds(int? id = null, int? categoryId = null)
    {
        var prodList = new List<ProductGetDto>();
        try 
        {
            prodList = (from prod in (await productoRepository.GetAll())
                join cat in await categoryRepository.GetAll() on prod.CategoriaId equals cat.Id
                where prod.Id == id || !id.HasValue
                where prod.CategoriaId == categoryId || !categoryId.HasValue
                select new ProductGetDto
                {
                    Id = prod.Id,
                    Nombre = prod.Nombre,
                    Descripcion = prod.Descripcion,
                    Categoria = cat.Nombre, //prod.CategoriaId
                    Precio = prod.Precio,
                    Stock = prod.Stock,
                    ImgUrl = prod.ImgUrl,
                    FechaCreacion = prod.FechaCreacion
                }).ToList();
        }
        catch (Exception e)
        {
            prodList = null;
            logger.Log(LogLevel.Error, "Error obtenindo productos", e.ToString());
        }

        return prodList;
    }
}
using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Application.Dtos.Orden;
using PcStore.Application.Extensions;
using PcStore.Domain.Entity;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Application.Services;

public class OrdenService : IOrdenService
{
    private readonly IOrdenRepository ordenRepository;
    private readonly IOrdenProductosRespository ordenProductosRespository;
    private readonly ILogger<OrdenService> logger;

    public OrdenService(IOrdenRepository ordenRepository, IOrdenProductosRespository ordenProductosRespository, ILogger<OrdenService> logger)
    {
        this.ordenRepository = ordenRepository;
        this.ordenProductosRespository = ordenProductosRespository;
        this.logger = logger;
    }
    public async Task<ServiceResult> GetOrds()
    {
        var result = new ServiceResult();
        try
        {
            result.Data = await Get();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniedo ordenes";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }
        return result;
    }
    public async Task<ServiceResult> GetOrdsById(int id)
    {
        var result = new ServiceResult();
        try
        {
            result.Data = (await Get(id)).FirstOrDefault();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniedo ordenes";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    public async Task<ServiceResult> Save(OrdenAddDto orden, List<OrdenProductAddDto> ordProds)
    {
        var result = new ServiceResult();
        try
        {
            decimal subTotal = 0;
            var newOrden = orden.ConvertOrdenAddDtoToOrden();
            var newOrdProds = ordProds.Select(item => item.ConvertOrdenProductAddToOrdenProduct()).ToList();

            foreach (var item in newOrdProds)
            {
                item.TotalPorProducto = item.Cantidad * item.PrecioPorProducto;
                subTotal += item.TotalPorProducto;
            }

            newOrden.SubTotal = subTotal;
            newOrden.Impuesto = subTotal * (decimal)0.18;
            newOrden.Total = newOrden.SubTotal + newOrden.Impuesto;
            var orderId = await ordenRepository.Save(newOrden);
            foreach (var item in newOrdProds)
            {
                item.OrdenId = orderId.Id;
            }
            await ordenProductosRespository.Save(newOrdProds.ToArray());
        }
        catch (Exception e)
        {
            result.Message = "Error obteniedo ordenes";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }
        return result;
    }
    private async Task<List<OrdenGetDto>> Get(int? id = null)
    {
        var ordList = new List<OrdenGetDto>();
        try
        {
            ordList = (from ord in (await ordenRepository.GetAll())
                join ordProd in await ordenProductosRespository.GetAll() on ord.Id equals ordProd.OrdenId into ords
                where ord.Id == id || !id.HasValue
                select new OrdenGetDto() 
                {
                    Id = ord.Id,
                    ClientId = ord.Id,
                    ClienteName = ord.ClienteName,
                    SubTotal = ord.SubTotal,
                    Impuesto = ord.Impuesto,
                    Total = ord.Total,
                    FechaCreacion = ord.FechaCreacion,
                    OrdProd = ords.ToList()
                }).ToList(); }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, "Error obteniedo ordenes", e.ToString());
        }
        return ordList;
    }
}
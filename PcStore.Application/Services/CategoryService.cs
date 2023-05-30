using Microsoft.Extensions.Logging;
using PcStore.Application.Contract;
using PcStore.Application.Core;
using PcStore.Application.Dtos.Category;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    private readonly ILogger<CategoryService> logger;

    public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
    {
        this.categoryRepository = categoryRepository;
        this.logger = logger;
    }

    public async Task<ServiceResult> GetCategory()
    {
        var result = new ServiceResult();
        try
        {
            result.Data = await GetCat();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo mensajes";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    public async Task<ServiceResult> GetCategoryById(int id)
    {
        var result = new ServiceResult();
        try
        {
            result.Data = (await GetCat(id)).FirstOrDefault();
        }
        catch (Exception e)
        {
            result.Message = "Error obteniendo mensajes";
            result.Success = false;
            logger.Log(LogLevel.Error, $"{result.Message}", e.ToString());
        }

        return result;
    }

    private async Task<List<CategoryDto>> GetCat(int? id = null)
    {
        var categories = new List<CategoryDto>();
        try
        {
            categories = (from cat in await categoryRepository.GetAll()
                where cat.Id == id || !id.HasValue
                select new CategoryDto
                {
                    Id = cat.Id,
                    Nombre = cat.Nombre
                }).ToList();
        }
        catch (Exception e)
        {
            categories = null;
            logger.Log(LogLevel.Error, "Error obteniendo categorias", e.ToString());
        }

        return categories;
    }
}
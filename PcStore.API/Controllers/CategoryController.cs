using Microsoft.AspNetCore.Mvc;
using PcStore.Application.Contract;

namespace PcStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;
    private readonly ILogger<CategoryController> logger;

    public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
    {
        this.categoryService = categoryService;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cats = await categoryService.GetCategory();
        return Ok(cats);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCatById(int id)
    {
        var cats = await categoryService.GetCategoryById(id);
        return Ok(cats);
    }
}
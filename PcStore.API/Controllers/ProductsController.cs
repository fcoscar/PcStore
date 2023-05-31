using Microsoft.AspNetCore.Mvc;
using PcStore.Application.Contract;

namespace PcStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var products = await productService.GetProductById(id);
        return Ok(products);
    }

    [HttpGet("categoria/{categoryId:int}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var products = await productService.GetProductByCategory(categoryId);
        return Ok(products);
    }
}
using Microsoft.AspNetCore.Mvc;
using PcStore.Application.Contract;
using PcStore.Infrastructure.Interfaces;

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
}
using Microsoft.AspNetCore.Mvc;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductoRepository productoRepository;

    public ProductsController(IProductoRepository productoRepository)
    {
        this.productoRepository = productoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await this.productoRepository.GetAll();
        return Ok(products);
    }
}
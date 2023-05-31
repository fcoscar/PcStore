using Microsoft.AspNetCore.Mvc;
using PcStore.Application.Contract;

namespace PcStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrdenController : ControllerBase
{
    private readonly IOrdenService ordenService;

    public OrdenController(IOrdenService ordenService)
    {
        this.ordenService = ordenService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ord = await ordenService.GetOrds();
        return Ok(ord);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ord = await ordenService.GetOrdsById(id);
        return Ok(ord);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] RequestParams request)
    {
        var ord = request.Orden;
        var ordsProds = request.OrdenProductos;
        var result = await ordenService.Save(ord, ordsProds);
        return Ok();
    }
}
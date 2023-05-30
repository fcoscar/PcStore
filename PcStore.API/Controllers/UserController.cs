using Microsoft.AspNetCore.Mvc;
using PcStore.Application.Contract;

namespace PcStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await userService.GetUsers();
        return Ok(users);
    }
}
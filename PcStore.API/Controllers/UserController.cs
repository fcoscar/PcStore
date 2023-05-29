using Microsoft.AspNetCore.Mvc;
using PcStore.Infrastructure.Interfaces;

namespace PcStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public UserController( IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await userRepository.GetAll();
        return Ok(users);
    }
}
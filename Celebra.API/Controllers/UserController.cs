using Celebra.Business.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Celebra.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _service) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(string ip)
    {
        await _service.CreateAsync(ip);
        return Ok();
    }
}

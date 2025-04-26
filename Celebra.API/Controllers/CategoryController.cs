using Celebra.Business.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace Celebra.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _service) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}

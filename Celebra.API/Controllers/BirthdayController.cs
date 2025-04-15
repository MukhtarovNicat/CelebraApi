using Celebra.Business.Dtos.BirthdayDtos;
using Celebra.Business.Services.Birthday;
using Celebra.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Celebra.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BirthdayController(IBirthdayService _service) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> BirthdayCreate(BirthdayCreateDto dto,string ip)
    {
        await _service.CreateAsync(dto, ip);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> BirthdayGetAll(string ip)
    {
        var result = await _service.GetAllAsync(ip);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllByCategory(CategoryType category, string ip)
    {
        return Ok(await _service.GetAllByCategoryAsync(category,ip));
    }
}

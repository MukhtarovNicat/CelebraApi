using Celebra.Business.Dtos.BirthdayDtos;
using Celebra.Business.Services.Birthday;
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
}

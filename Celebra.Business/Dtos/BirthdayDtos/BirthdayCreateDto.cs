using Celebra.Core.Entities;
using Celebra.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Celebra.Business.Dtos.BirthdayDtos;
//TODO : Validasiyalar
public record BirthdayCreateDto
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    public IFormFile? Image { get; set; }
    public DateTime BirthDate { get; set; }
    public RemindDate? RemindDate { get; set; }
    public DateTime? RemindTime { get; set; }
    public Category Category { get; set; }
}

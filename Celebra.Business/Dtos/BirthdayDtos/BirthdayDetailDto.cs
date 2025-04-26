using Celebra.Core.Enums;

namespace Celebra.Business.Dtos.BirthdayDtos;

public record BirthdayDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Image { get; set; }
    public DateTime BirthDate { get; set; }
    public ZodiacSign ZodiacSign { get; set; }
    public ChineseZodiacSign ChineseZodiacSign { get; set; }
}

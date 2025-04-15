using Celebra.Core.Enums;

namespace Celebra.Business.Dtos.BirthdayDtos;

public class BirthdayGetAllDto
{
    public Guid Id { get; set; } 
    public string FullName { get; set; }
    public string? Image { get; set; }
    public DateTime BirthDate { get; set; }
    public ZodiacSign ZodiacSign { get; set; }
    public ChineseZodiacSign ChineseZodiacSign { get; set; }
}

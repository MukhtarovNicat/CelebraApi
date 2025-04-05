using Celebra.Core.Entities.Common;
using Celebra.Core.Enums;

namespace Celebra.Core.Entities;

public class Birthday : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Image { get; set; }
    public DateTime BirthDate { get; set; }
    public ZodiacSign ZodiacSign { get; set; }
    public ChineseZodiacSign ChineseZodiacSign { get; set; }
    public RemindDate RemindDate { get; set; }
    public DateTime RemindTime { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}

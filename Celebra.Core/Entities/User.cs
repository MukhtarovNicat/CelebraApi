using Celebra.Core.Entities.Common;

namespace Celebra.Core.Entities;

public class User : BaseEntity
{
    public string Ip { get; set; }
    public ICollection<Birthday>? Birthdays { get; set; }
}

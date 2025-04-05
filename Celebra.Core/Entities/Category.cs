using Celebra.Core.Entities.Common;
using Celebra.Core.Enums;

namespace Celebra.Core.Entities;

public class Category : BaseEntity
{
    public CategoryType Name { get; set; }
    public ICollection<Birthday> Birthdays { get; set; }
}

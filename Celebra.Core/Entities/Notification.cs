using Celebra.Core.Entities.Common;

namespace Celebra.Core.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsSeen { get; set; }
    public string? InformationFullName { get; set; }
}

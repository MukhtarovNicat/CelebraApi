namespace Celebra.Business.Dtos.NotificationDtos;

public class NotificationCreateDto
{
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? InformationFullName { get; set; }
}

using Celebra.Business.Dtos.NotificationDtos;

namespace Celebra.Business.Services.Notification;

public interface INotificationService
{
    Task CreateNotificationAsync(NotificationCreateDto dto);
}

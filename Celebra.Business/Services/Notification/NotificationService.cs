using Celebra.Business.Dtos.NotificationDtos;
using Celebra.DAL.Contexts;

namespace Celebra.Business.Services.Notification;

public class NotificationService(AppDbContext _context) : INotificationService
{
    public async Task CreateNotificationAsync(NotificationCreateDto dto)
    {
        var notification = new Core.Entities.Notification
        {
            UserId = dto.UserId,
            CreatedDate = dto.CreatedDate,
            InformationFullName = dto.InformationFullName,
            IsSeen = false
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }
}

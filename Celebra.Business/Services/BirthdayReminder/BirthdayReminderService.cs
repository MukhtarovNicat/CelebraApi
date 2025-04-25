using Celebra.Business.Dtos.NotificationDtos;
using Celebra.Business.Services.Notification;
using Celebra.Core.Enums;
using Celebra.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Celebra.Business.Services.BirthdayReminder;

public class BirthdayReminderService(AppDbContext _context, ILogger<BirthdayReminderService> _logger, INotificationService _notificationService) : IBirthdayReminderService
{
    public async Task CheckBirthdaysAsync()
    {
        var now = DateTime.UtcNow.AddHours(4);

        Console.WriteLine(now);

        var today = now.Date;

        Console.WriteLine(today);

        var birthdays = await _context.Birthdays
            .Include(b => b.User)
            .ToListAsync();

        foreach (var birthday in birthdays)
        {
            var birthDate = birthday.BirthDate;

            var birthdayThisYear = new DateTime(today.Year, birthDate.Month, birthDate.Day);

            var remindDays = (int)birthday.RemindDate;
            var remindDate = birthdayThisYear.AddDays(-remindDays);

            var remindHour = birthday.RemindTime.Hour;
            var remindMinute = birthday.RemindTime.Minute;

            if (today == remindDate && now.Hour == remindHour && now.Minute == remindMinute)
            {
                SendNotification(birthday);
            }
        }
    }

    private async void SendNotification(Core.Entities.Birthday birthday)
    {
        _logger.LogInformation($"{birthday.Name} {birthday.Surname} üçün bildiriş göndərildi!");

        var notificationDto = new NotificationCreateDto
        {
            UserId = birthday.UserId,
            CreatedDate = DateTime.UtcNow,
            InformationFullName = $"{birthday.Name} {birthday.Surname}"
        };

        await _notificationService.CreateNotificationAsync(notificationDto);
    }
}

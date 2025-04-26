using Celebra.Business.ExternalServices.FileService;
using Celebra.Business.Services.Birthday;
using Celebra.Business.Services.BirthdayReminder;
using Celebra.Business.Services.Category;
using Celebra.Business.Services.Notification;
using Celebra.Business.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Celebra.Business;

public static class ServiceRegistration 
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IBirthdayService, BirthdayService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBirthdayReminderService, BirthdayReminderService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}

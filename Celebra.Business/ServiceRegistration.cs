using Celebra.Business.ExternalServices.FileService;
using Celebra.Business.Services.Birthday;
using Microsoft.Extensions.DependencyInjection;

namespace Celebra.Business;

public static class ServiceRegistration 
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBirthdayService, BirthdayService>();
        services.AddScoped<IFileService, FileService>();
    }
}

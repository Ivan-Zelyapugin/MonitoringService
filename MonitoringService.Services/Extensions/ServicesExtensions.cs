using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IDeviceService, DeviceService>()
                .AddScoped<ISessionService, SessionService>()
                .AddScoped<IBackupService, BackupService>()
                .AddScoped<IMonitoringService, MonitoringService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services.Extensions
{
    /// <summary>
    /// Класс с методами расширения для добавления функциональности сервисного слоя.
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Добавляет сервисы.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
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

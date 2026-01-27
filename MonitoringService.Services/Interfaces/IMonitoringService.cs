using MonitoringService.Services.Models;

namespace MonitoringService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс основного сервиса мониторинга устройств.
    /// </summary>
    public interface IMonitoringService
    {
        /// <summary>
        /// Обрабатывает данные активности устройства и добавляет их в систему.
        /// </summary>
        /// <param name="dto">DTO с данными активности устройства.</param>
        Task ProcessAsync(DeviceActivityDto dto);
    }
}

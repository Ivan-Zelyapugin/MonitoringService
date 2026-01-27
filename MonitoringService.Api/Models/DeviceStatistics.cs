using MonitoringService.Models;

namespace MonitoringService.Api.Models
{
    /// <summary>
    /// Модель статистики по устройству, включая информацию об устройстве и его сессиях активности.
    /// </summary>
    public class DeviceStatistics
    {
        /// <summary>
        /// Информация об устройстве.
        /// </summary>
        public Device Device { get; set; } = null!;

        /// <summary>
        /// Список сессий активности данного устройства.
        /// </summary>
        public List<ActivitySession> Sessions { get; set; } = [];
    }
}

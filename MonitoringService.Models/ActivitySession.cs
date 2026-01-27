namespace MonitoringService.Models
{
    /// <summary>
    /// Модель сессии активности устройства.
    /// </summary>
    public class ActivitySession
    {
        /// <summary>
        /// Уникальный идентификатор сессии.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id устройства, к которому относится сессия.
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Время начала сессии активности устройства.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии активности устройства.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}

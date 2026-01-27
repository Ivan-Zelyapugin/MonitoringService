namespace MonitoringService.Services.Models
{
    /// <summary>
    /// DTO для передачи данных активности устройства.
    /// </summary>
    public class DeviceActivityDto
    {
        /// <summary>
        /// Идентификатор устройства.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Время начала активности устройства.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания активности устройства.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Версия установленного приложения
        /// </summary>
        public string Version { get; set; } = string.Empty;
    }
}

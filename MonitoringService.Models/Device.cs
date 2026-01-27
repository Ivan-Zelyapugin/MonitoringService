namespace MonitoringService.Models
{
    /// <summary>
    /// Модель устройства.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Уникальный идентификатор устройства.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Версия установленного приложения
        /// </summary>
        public string Version {  get; set; } = string.Empty;
    }
}

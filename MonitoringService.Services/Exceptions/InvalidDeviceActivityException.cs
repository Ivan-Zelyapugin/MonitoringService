namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается при некорректных данных активности устройства.
    /// Наследуется от <see cref="BadRequestException"/>.
    /// </summary>
    public sealed class InvalidDeviceActivityException : BadRequestException
    {
        /// <summary>
        /// Исключение, которое выбрасывается при некорректных данных активности устройства.
        /// Наследуется от <see cref="BadRequestException"/>.
        /// </summary>
        public InvalidDeviceActivityException() : base("Некорректные данные активности устройства") { }
    }
}

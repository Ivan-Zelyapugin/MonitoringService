namespace MonitoringService.Services.Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается, когда устройство не найдено.
    /// Наследуется от <see cref="NotFoundException"/>.
    /// </summary>
    public sealed class DeviceNotFoundException : NotFoundException
    {
        public DeviceNotFoundException(Guid id) : base($"Устройство {id} не найдено") { }
    }
}

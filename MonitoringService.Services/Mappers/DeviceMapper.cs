using MonitoringService.Models;
using MonitoringService.Services.Models;

namespace MonitoringService.Services.Mappers
{
    /// <summary>
    /// Статический класс для преобразования DTO активности устройства (<see cref="DeviceActivityDto"/>) 
    /// в модели домена (<see cref="Device"/> и <see cref="ActivitySession"/>).
    /// </summary>
    public static class DeviceMapper
    {
        /// <summary>
        /// Преобразует DTO активности устройства в объект <see cref="Device"/>.
        /// </summary>
        /// <param name="source">Объект DTO активности устройства.</param>
        /// <returns>Экземпляр <see cref="Device"/> с соответствующими полями или <c>null</c>, если DTO равен <c>null</c>.</returns>
        public static Device MapToDevice(this DeviceActivityDto source)
        {
            return source == null
            ? default
            : new Device
            {
                Id = source.Id,
                Name = source.Name,
                Version = source.Version
            };
        }

        /// <summary>
        /// Преобразует DTO активности устройства в объект <see cref="ActivitySession"/>.
        /// Генерируется новый <see cref="Guid"/> для Id сессии.
        /// </summary>
        /// <param name="source">Объект DTO активности устройства.</param>
        /// <returns>Экземпляр <see cref="ActivitySession"/> с соответствующими полями или <c>null</c>, если DTO равен <c>null</c>.</returns>
        public static ActivitySession MapToSession(this DeviceActivityDto source)
        {
            return source == null
                ? default
                : new ActivitySession
                {
                    Id = Guid.NewGuid(),
                    DeviceId = source.Id,
                    StartTime = source.StartTime,
                    EndTime = source.EndTime
                };
        }
    }
}

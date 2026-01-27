using MonitoringService.Models;

namespace MonitoringService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с сессиями устройств.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Добавляет новую сессию активности устройства.
        /// </summary>
        /// <param name="session">Объект сессии активности.</param>
        Task AddAsync(ActivitySession session);

        /// <summary>
        /// Получает список всех сессий по идентификатору устройства.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Список сессий для данного устройства.</returns>
        Task<List<ActivitySession>> GetByDeviceIdAsync(Guid deviceId);
    }
}

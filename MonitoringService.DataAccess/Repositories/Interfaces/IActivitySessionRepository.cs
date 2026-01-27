using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сессиями активности устройств.
    /// </summary>
    public interface IActivitySessionRepository
    {
        /// <summary>
        /// Добавляет новую сессию активности устройства.
        /// </summary>
        /// <param name="session">Модель сессии <see cref="ActivitySession"/> для добавления.</param>
        Task AddSessionAsync(ActivitySession session);

        /// <summary>
        /// Получает все сессии активности для конкретного устройства.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Список сессий <see cref="ActivitySession"/> для указанного устройства. Если сессий нет, возвращается пустой список.</returns>
        Task<List<ActivitySession>> GetSessionsByDeviceIdAsync(Guid deviceId);
    }
}

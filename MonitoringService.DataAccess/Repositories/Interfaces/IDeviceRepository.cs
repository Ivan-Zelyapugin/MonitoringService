using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с устройствами.
    /// </summary>
    public interface IDeviceRepository
    {
        /// <summary>
        /// Добавляет новое устройство в базу данных.
        /// </summary>
        /// <param name="device">Модель устройства <see cref="Device"/> для добавления.</param>
        Task AddDeviceAsync(Device device);

        /// <summary>
        /// Получает устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Уникальный идентификатор устройства.</param>
        /// <returns>Объект <see cref="Device"/> с указанным идентификатором или null, если устройство не найдено.</returns>
        Task<Device> GetDeviceAsync(Guid deviceId);

        /// <summary>
        /// Получает список всех устройств.
        /// </summary>
        /// <returns>Список объектов <see cref="Device"/>. Если устройств нет, возвращается пустой список.</returns>
        Task<List<Device>> GetAllDevicesAsync();
    }
}

using MonitoringService.Models;

namespace MonitoringService.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса управления устройствами.
    /// </summary>
    public interface IDeviceService
    {
        /// <summary>
        /// Получает устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>Объект устройства.</returns>
        Task<Device> GetAsync(Guid id);

        /// <summary>
        /// Получает все устройства.
        /// </summary>
        /// <returns>Список всех устройств.</returns>
        Task<List<Device>> GetAllAsync();

        /// <summary>
        /// Создаёт новое устройство в системе.
        /// </summary>
        /// <param name="device">Объект устройства для добавления.</param>
        Task CreateAsync(Device device);
    }
}

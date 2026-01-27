using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services
{
    /// <summary>
    /// Сервис для работы с устройствами.
    /// </summary>
    public class DeviceService(IDeviceRepository repository, ILogger<DeviceService> logger) : IDeviceService
    {
        /// <inheritdoc />
        public async Task<Device> GetAsync(Guid id)
        {
            logger.LogInformation("Запрос устройства {DeviceId}", id);

            var device = await repository.GetDeviceAsync(id);

            logger.LogDebug("Устройство {DeviceId} успешно найдено", id);

            return device;
        }

        /// <inheritdoc />
        public async Task<List<Device>> GetAllAsync()
        {
            logger.LogInformation("Запрос всех устройств");

            return await repository.GetAllDevicesAsync();
        }

        /// <inheritdoc />
        public async Task CreateAsync(Device device)
        {
            logger.LogInformation("Создание устройства {DeviceId}", device.Id);

            await repository.AddDeviceAsync(device);

            logger.LogInformation("Устройство {DeviceId} успешно создано", device.Id);
        }
    }
}

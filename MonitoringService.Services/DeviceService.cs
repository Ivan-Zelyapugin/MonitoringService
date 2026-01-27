using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.Models;
using MonitoringService.Services.Exceptions;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services
{
    /// <summary>
    /// Сервис для работы с устройствами.
    /// </summary>
    public class DeviceService(IDeviceRepository repository, ILogger<DeviceService> logger) : IDeviceService
    {
        public async Task<Device> GetAsync(Guid id)
        {
            logger.LogInformation("Запрос устройства {DeviceId}", id);

            var device = await repository.GetDeviceAsync(id);

            if (device == null)
            {
                throw new DeviceNotFoundException(id);
            }

            logger.LogDebug("Устройство {DeviceId} успешно найдено", id);

            return device;
        }

        public async Task<List<Device>> GetAllAsync()
        {
            logger.LogInformation("Запрос всех устройств");

            return await repository.GetAllDevicesAsync();
        }

        public async Task CreateAsync(Device device)
        {
            logger.LogInformation("Создание устройства {DeviceId}", device.Id);

            await repository.AddDeviceAsync(device);

            logger.LogInformation("Устройство {DeviceId} успешно создано", device.Id);
        }
    }
}

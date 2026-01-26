using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services
{
    public class DeviceService(IDeviceRepository repository, ILogger<DeviceService> logger) : IDeviceService
    {
        public async Task<Device> GetAsync(Guid id)
        {
            logger.LogInformation("Запрос устройства {DeviceId}", id);
            try
            {
                var device = await repository.GetDeviceAsync(id);

                if (device == null)
                {
                    logger.LogWarning("Устройство {DeviceId} не найдено", id);
                }
                else
                {
                    logger.LogInformation("Устройство {DeviceId} успешно получено", id);
                }

                return device;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при получении устройства {DeviceId}", id);
                throw;
            }
            
        }

        public async Task<List<Device>> GetAllAsync()
        {
            logger.LogInformation("Запрос всех устройств");

            try
            {
                var devices = await repository.GetAllDevicesAsync();
                logger.LogDebug("Получено {Count} устройств", devices.Count);
                return devices;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при получении всех устройств");
                throw;
            }
        }

        public async Task CreateAsync(Device device)
        {
            logger.LogInformation("Создание устройства {DeviceId}", device.Id);

            try
            {
                await repository.AddDeviceAsync(device);
                logger.LogInformation("Устройство {DeviceId} успешно создано", device.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при создании устройства {DeviceId}", device.Id);
                throw;
            }
        }
    }
}

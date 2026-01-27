using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Dapper.Interfaces;
using MonitoringService.DataAccess.Dapper.Models;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.DataAccess.Repositories.Scripts;
using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с устройствами.
    /// </summary>
    public class DeviceRepository(IDapperContext<IDapperSettings> dapperContext, ILogger<DeviceRepository> logger) : IDeviceRepository
    {
        /// <inheritdoc />
        public async Task AddDeviceAsync(Device device)
        {
            logger.LogInformation("Добавление нового устройства {DeviceId}", device.Id);
            await dapperContext.Command(new QueryObject(Sql.AddDevice, device));
            logger.LogInformation("Устройство {DeviceId} успешно добавлено", device.Id);
        }

        /// <inheritdoc />
        public async Task<Device> GetDeviceAsync(Guid deviceId)
        {
            logger.LogDebug("Запрос Device из БД {DeviceId}", deviceId);
            return await dapperContext.FirstOrDefault<Device>(new QueryObject(Sql.GetDevice, new { deviceId }));
        }

        /// <inheritdoc />
        public async Task<List<Device>> GetAllDevicesAsync()
        {
            logger.LogDebug("Запрос всех устройств из БД");
            var devices = await dapperContext.ListOrEmpty<Device>(new QueryObject(Sql.GetAllDevices));
            logger.LogDebug("Получено {Count} устройств", devices.Count);
            return devices;
        }
    }
}

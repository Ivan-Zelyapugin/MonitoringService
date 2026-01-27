using Microsoft.Extensions.Logging;
using MonitoringService.Services.Exceptions;
using MonitoringService.Services.Interfaces;
using MonitoringService.Services.Mappers;
using MonitoringService.Services.Models;

namespace MonitoringService.Services
{
    /// <summary>
    /// Сервис для обработки данных активности устройства.
    /// </summary>
    public class MonitoringService(IDeviceService deviceService, ISessionService sessionService, ILogger<MonitoringService> logger) : IMonitoringService
    {
        public async Task ProcessAsync(DeviceActivityDto dto)
        {
            logger.LogInformation("Обработка данных активности устройства {DeviceId}", dto.Id);

            if (dto == null ||
                dto.Id == Guid.Empty ||
                string.IsNullOrWhiteSpace(dto.Name) ||
                dto.StartTime == default ||
                dto.EndTime == default ||
                string.IsNullOrWhiteSpace(dto.Version))
            {
                logger.LogWarning("Некорректные данные активности устройства {DeviceId}", dto?.Id);
                throw new InvalidDeviceActivityException();
            }

            var device = await deviceService.GetAsync(dto.Id);

            if (device == null)
            {
                await deviceService.CreateAsync(dto.MapToDevice());
                logger.LogInformation("Устройство {DeviceId} успешно создано", dto.Id);
            }

            await sessionService.AddAsync(dto.MapToSession());
            logger.LogInformation("Сессия для устройства {DeviceId} успешно добавлена", dto.Id);

        }
    }
}

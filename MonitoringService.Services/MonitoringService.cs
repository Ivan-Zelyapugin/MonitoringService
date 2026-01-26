using Microsoft.Extensions.Logging;
using MonitoringService.Services.Interfaces;
using MonitoringService.Services.Mappers;
using MonitoringService.Services.Models;

namespace MonitoringService.Services
{
    public class MonitoringService(IDeviceService deviceService, ISessionService sessionService, ILogger<MonitoringService> logger) : IMonitoringService
    {
        public async Task ProcessAsync(DeviceActivityDto dto)
        {
            logger.LogInformation("Обработка данных активности устройства {DeviceId}", dto.Id);

            try
            {
                var device = await deviceService.GetAsync(dto.Id);

                if (device == null)
                {
                    logger.LogInformation("Устройство {DeviceId} не найдено, создаём новое", dto.Id);
                    await deviceService.CreateAsync(dto.MapToDevice());
                    logger.LogInformation("Устройство {DeviceId} успешно создано", dto.Id);
                }

                await sessionService.AddAsync(dto.MapToSession());
                logger.LogInformation("Сессия для устройства {DeviceId} успешно добавлена", dto.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при обработке активности устройства {DeviceId}", dto.Id);
                throw;
            }
        }
    }
}

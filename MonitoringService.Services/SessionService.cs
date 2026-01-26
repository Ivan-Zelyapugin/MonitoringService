using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services
{
    public class SessionService(IActivitySessionRepository repository, ILogger<SessionService> logger) : ISessionService
    {
        public async Task AddAsync(ActivitySession session)
        {
            logger.LogInformation("Добавление сессии для устройства {DeviceId}", session.DeviceId);

            try
            {
                await repository.AddSessionAsync(session);
                logger.LogInformation("Сессия для устройства {DeviceId} успешно добавлена", session.DeviceId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при добавлении сессии для устройства {DeviceId}", session.DeviceId);
                throw;
            }
        }

        public async Task<List<ActivitySession>> GetByDeviceIdAsync(Guid deviceId)
        {
            logger.LogInformation("Запрос всех сессий для устройства {DeviceId}", deviceId);

            try
            {
                var sessions = await repository.GetSessionsByDeviceIdAsync(deviceId);
                logger.LogDebug("Получено {Count} сессий для устройства {DeviceId}", sessions.Count, deviceId);
                return sessions;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при получении сессий для устройства {DeviceId}", deviceId);
                throw;
            }
        }
    }
}

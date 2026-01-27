using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Services
{
    /// <summary>
    /// Сервис для работы с сессиями активности устройств.
    /// </summary>
    public class SessionService(IActivitySessionRepository repository, ILogger<SessionService> logger) : ISessionService
    {
        public async Task AddAsync(ActivitySession session)
        {
            logger.LogInformation("Добавление сессии {DeviceId}", session.DeviceId);
            await repository.AddSessionAsync(session);
        }

        public async Task<List<ActivitySession>> GetByDeviceIdAsync(Guid deviceId)
        {
            logger.LogInformation("Запрос сессий {DeviceId}", deviceId);
            return await repository.GetSessionsByDeviceIdAsync(deviceId);
        }
    }
}

using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Dapper.Interfaces;
using MonitoringService.DataAccess.Dapper.Models;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.DataAccess.Repositories.Scripts;
using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с сессиями активности устройств.
    /// </summary>
    public class ActivitySessionRepository(IDapperContext<IDapperSettings> dapperContext, ILogger<ActivitySessionRepository> logger) : IActivitySessionRepository
    {
        public async Task AddSessionAsync(ActivitySession session)
        {
            logger.LogInformation("Добавление новой сессии для устройства {DeviceId}", session.DeviceId);
            await dapperContext.Command(new QueryObject(Sql.AddSession, session));
            logger.LogInformation("Сессия для устройства {DeviceId} успешно добавлена", session.DeviceId);
        }

        public async Task<List<ActivitySession>> GetSessionsByDeviceIdAsync(Guid deviceId)
        {
            logger.LogDebug("Запрос всех сессий для устройства {DeviceId}", deviceId);
            var sessions = await dapperContext.ListOrEmpty<ActivitySession>(new QueryObject(Sql.GetSessionsByDeviceId, new { DeviceId = deviceId }));
            logger.LogDebug("Получено {Count} сессий для устройства {DeviceId}", sessions.Count, deviceId);
            return sessions;
        }
    }
}

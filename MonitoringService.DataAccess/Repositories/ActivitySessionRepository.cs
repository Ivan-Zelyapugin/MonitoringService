using Microsoft.Extensions.Logging;
using MonitoringService.DataAccess.Dapper.Interfaces;
using MonitoringService.DataAccess.Dapper.Models;
using MonitoringService.DataAccess.Repositories.Interfaces;
using MonitoringService.DataAccess.Repositories.Scripts;
using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories
{
    public class ActivitySessionRepository(IDapperContext<IDapperSettings> dapperContext, ILogger<ActivitySessionRepository> logger) : IActivitySessionRepository
    {
        public async Task AddSessionAsync(ActivitySession session)
        {
            logger.LogInformation("Добавление новой сессии для устройства {DeviceId}", session.DeviceId);

            try
            {
                await dapperContext.Command(new QueryObject(Sql.AddSession, session));
                logger.LogInformation("Сессия для устройства {DeviceId} успешно добавлена", session.DeviceId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при добавлении сессии для устройства {DeviceId}", session.DeviceId);
                throw;
            }
        }

        public async Task<List<ActivitySession>> GetSessionsByDeviceIdAsync(Guid deviceId)
        {
            logger.LogDebug("Запрос всех сессий для устройства {DeviceId}", deviceId);

            try
            {
                var sessions = await dapperContext.ListOrEmpty<ActivitySession>(new QueryObject(Sql.GetSessionsByDeviceId, new { DeviceId = deviceId }));
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

using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories.Interfaces
{
    public interface IActivitySessionRepository
    {
        Task AddSessionAsync(ActivitySession session);
        Task<List<ActivitySession>> GetSessionsByDeviceIdAsync(Guid deviceId);
    }
}

using MonitoringService.Models;

namespace MonitoringService.Services.Interfaces
{
    public interface ISessionService
    {
        Task AddAsync(ActivitySession session);
        Task<List<ActivitySession>> GetByDeviceIdAsync(Guid deviceId);
    }
}

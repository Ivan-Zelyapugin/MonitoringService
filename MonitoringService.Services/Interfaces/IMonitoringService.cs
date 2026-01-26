using MonitoringService.Services.Models;

namespace MonitoringService.Services.Interfaces
{
    public interface IMonitoringService
    {
        Task ProcessAsync(DeviceActivityDto dto);
    }
}

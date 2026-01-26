using MonitoringService.Models;

namespace MonitoringService.Api.Models
{
    public class DeviceStatistics
    {
        public Device Device { get; set; } = null!;
        public List<ActivitySession> Sessions { get; set; } = [];
    }
}

using MonitoringService.Models;
using MonitoringService.Services.Models;

namespace MonitoringService.Services.Mappers
{
    public static class DeviceMapper
    {
        public static Device MapToDevice(this DeviceActivityDto source)
        {
            return source == null
            ? default
            : new Device
            {
                Id = source.Id,
                Name = source.Name,
                Version = source.Version
            };
        }

        public static ActivitySession MapToSession(this DeviceActivityDto source)
        {
            return source == null
                ? default
                : new ActivitySession
                {
                    Id = Guid.NewGuid(),
                    DeviceId = source.Id,
                    StartTime = source.StartTime,
                    EndTime = source.EndTime
                };
        }
    }
}

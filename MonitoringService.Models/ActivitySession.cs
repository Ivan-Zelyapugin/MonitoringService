namespace MonitoringService.Models
{
    public class ActivitySession
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

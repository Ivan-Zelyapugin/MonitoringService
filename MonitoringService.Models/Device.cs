namespace MonitoringService.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Version {  get; set; } = string.Empty;
    }
}

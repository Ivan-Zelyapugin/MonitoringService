using MonitoringService.Models;

namespace MonitoringService.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<Device> GetAsync(Guid id);
        Task<List<Device>> GetAllAsync();
        Task CreateAsync(Device device);
    }
}

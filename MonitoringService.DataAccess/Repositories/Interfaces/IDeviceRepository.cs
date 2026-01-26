using MonitoringService.Models;

namespace MonitoringService.DataAccess.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task AddDeviceAsync(Device device);
        Task<Device> GetDeviceAsync(Guid deviceId);
        Task<List<Device>> GetAllDevicesAsync();
    }
}

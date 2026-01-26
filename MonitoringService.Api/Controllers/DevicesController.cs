using Microsoft.AspNetCore.Mvc;
using MonitoringService.Api.Models;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Api.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController(IDeviceService deviceService, ISessionService sessionService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Device>> GetAllDevices()
        {
            return await deviceService.GetAllAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<DeviceStatistics> GetDevice(Guid id)
        {
            var device = await deviceService.GetAsync(id);

            var sessions = await sessionService.GetByDeviceIdAsync(id);

            return new DeviceStatistics
            {
                Device = device,
                Sessions = sessions
            };
        }
    }
}

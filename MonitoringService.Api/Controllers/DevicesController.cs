using Microsoft.AspNetCore.Mvc;
using MonitoringService.Api.Models;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с устройствами.
    /// </summary>
    [ApiController]
    [Route("api/devices")]
    public class DevicesController(IDeviceService deviceService, ISessionService sessionService) : ControllerBase
    {
        /// <summary>
        /// Получает список всех устройств.
        /// </summary>
        /// <returns>Список объектов <see cref="Device"/>.</returns>
        [HttpGet]
        public async Task<List<Device>> GetAllDevices()
        {
            return await deviceService.GetAllAsync();
        }

        /// <summary>
        /// Получает устройство по Id вместе с его сессиями.
        /// </summary>
        /// <param name="id">Id устройства.</param>
        /// <returns>Объект <see cref="DeviceStatistics"/> с устройством и сессиями.</returns>
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

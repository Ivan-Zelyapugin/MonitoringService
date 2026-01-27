using Microsoft.AspNetCore.Mvc;
using MonitoringService.Services.Interfaces;
using MonitoringService.Services.Models;

namespace MonitoringService.Api.Controllers
{
    /// <summary>
    /// Контроллер для приема данных активности устройств.
    /// </summary>
    [ApiController]
    [Route("api/activity")]
    public class ActivityController (IMonitoringService monitoringService) : ControllerBase
    {
        /// <summary>
        /// Обрабатывает данные активности устройства и добавляет сессию.
        /// </summary>
        /// <param name="request">DTO с информацией о активности устройства.</param>
        /// <returns>HTTP 200 OK при успешной обработке.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(DeviceActivityDto request)
        {
            await monitoringService.ProcessAsync(request);
            return Ok();
        }
    }
}

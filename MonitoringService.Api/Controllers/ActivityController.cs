using Microsoft.AspNetCore.Mvc;
using MonitoringService.Services.Interfaces;
using MonitoringService.Services.Models;

namespace MonitoringService.Api.Controllers
{
    [ApiController]
    [Route("api/activity")]
    public class ActivityController (IMonitoringService monitoringService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(DeviceActivityDto request)
        {
            await monitoringService.ProcessAsync(request);
            return Ok();
        }
    }
}

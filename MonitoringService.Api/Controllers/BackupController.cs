using Microsoft.AspNetCore.Mvc;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Api.Controllers
{
    [ApiController]
    [Route("api/backup")]
    public class BackupController(IBackupService backupService, ILogger<BackupController> logger) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBackup()
        {
            var (fileContent, fileName) = await backupService.BackupAsync();
            return File(fileContent, "application/json", fileName);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MonitoringService.Services.Interfaces;

namespace MonitoringService.Api.Controllers
{
    /// <summary>
    /// Контроллер для создания бэкапов данных.
    /// </summary>
    [ApiController]
    [Route("api/backup")]
    public class BackupController(IBackupService backupService, ILogger<BackupController> logger) : ControllerBase
    {
        /// <summary>
        /// Создает бэкап всех устройств и сессий.
        /// </summary>
        /// <returns>Файл JSON с данными бэкапа.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateBackup()
        {
            var (fileContent, fileName) = await backupService.BackupAsync();
            return File(fileContent, "application/json", fileName);
        }
    }
}

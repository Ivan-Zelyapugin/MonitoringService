using Microsoft.Extensions.Logging;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;
using System.Text.Json;

namespace MonitoringService.Services
{
    /// <summary>
    /// Сервис для создания бэкапов устройств и их сессий.
    /// </summary>
    public class BackupService(IDeviceService deviceService, ISessionService sessionService, ILogger<BackupService> logger) : IBackupService
    {
        private readonly string _backupFolder = "backups";

        /// <inheritdoc />
        public async Task<(byte[] FileContent, string FileName)> BackupAsync()
        {
            logger.LogInformation("Начало создания бэкапа");

            try
            {
                if (!Directory.Exists(_backupFolder))
                    Directory.CreateDirectory(_backupFolder);

                var devices = await deviceService.GetAllAsync();

                var sessions = new List<ActivitySession>();
                foreach (var device in devices)
                {
                    sessions.AddRange(await sessionService.GetByDeviceIdAsync(device.Id));
                }

                var fileName = $"backup_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
                var filePath = Path.Combine(_backupFolder, fileName);

                var json = JsonSerializer.Serialize(new
                {
                    Devices = devices,
                    Sessions = sessions,
                    CreatedAt = DateTime.UtcNow
                }, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(filePath, json);

                logger.LogInformation("Бэкап успешно создан: {FileName}", fileName);

                var fileContent = await File.ReadAllBytesAsync(filePath);
                return (fileContent, fileName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при создании бэкапа");
                throw;
            }
        }
    }
}

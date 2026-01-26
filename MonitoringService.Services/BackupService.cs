using Microsoft.Extensions.Logging;
using MonitoringService.Models;
using MonitoringService.Services.Interfaces;
using System.Text.Json;

namespace MonitoringService.Services
{
    public class BackupService(IDeviceService deviceService, ISessionService sessionService, ILogger<BackupService> logger) : IBackupService
    {
        private readonly string _backupFolder = "backups";

        public async Task<(byte[] FileContent, string FileName)> BackupAsync()
        {
            try
            {
                logger.LogInformation("Начало создания бэкапа");

                if (!Directory.Exists(_backupFolder))
                    Directory.CreateDirectory(_backupFolder);

                var devices = await deviceService.GetAllAsync();

                var sessions = new List<ActivitySession>();
                foreach (var device in devices)
                {
                    var deviceSessions = await sessionService.GetByDeviceIdAsync(device.Id);
                    sessions.AddRange(deviceSessions);
                }

                var backupData = new
                {
                    Devices = devices,
                    Sessions = sessions,
                    CreatedAt = DateTime.UtcNow
                };

                var fileName = $"backup_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
                var filePath = Path.Combine(_backupFolder, fileName);

                var json = JsonSerializer.Serialize(backupData, new JsonSerializerOptions { WriteIndented = true });
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

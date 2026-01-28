using Microsoft.Extensions.Logging.Abstractions;
using MonitoringService.Models;
using MonitoringService.Services.Exceptions;
using MonitoringService.Services.Interfaces;
using MonitoringService.Services.Models;
using Moq;

namespace MonitoringService.Tests
{
    /// <summary>
    /// Тесты для <see cref="MonitoringService.Services.MonitoringService"/>.
    /// Проверяют обработку данных активности устройства.
    /// </summary>
    public class MonitoringServiceTests
    {
        public MonitoringServiceTests()
        {
            var logger = new NullLogger<MonitoringService.Services.MonitoringService>();
            _service = new MonitoringService.Services.MonitoringService(
                _deviceServiceMock.Object,
                _sessionServiceMock.Object,
                logger);
        }

        /// <summary>
        /// Проверяет, что при передаче некорректного DTO выбрасывается <see cref="InvalidDeviceActivityException"/>.
        /// </summary>
        [Fact]
        public async Task ProcessAsync_InvalidDto_ThrowsInvalidDeviceActivityException()
        {
            // Arrange
            var dto = new DeviceActivityDto
            {
                Id = Guid.Empty, 
                Name = "",
                Version = ""
            };

            // Act and Assert
            await Assert.ThrowsAsync<InvalidDeviceActivityException>(() =>
                _service.ProcessAsync(dto));
        }

        /// <summary>
        /// Проверяет, что если устройство не существует, то создается новое устройство и добавляется сессия.
        /// </summary>
        [Fact]
        public async Task ProcessAsync_DeviceDoesNotExist_CreatesDeviceAndAddsSession()
        {
            // Arrange
            var dto = new DeviceActivityDto
            {
                Id = Guid.NewGuid(),
                Name = "Device1",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(1),
                Version = "1.0"
            };

            _deviceServiceMock
                .Setup(d => d.CreateAsync(It.IsAny<Device>()))
                .Returns(Task.CompletedTask);

            _sessionServiceMock
                .Setup(s => s.AddAsync(It.IsAny<ActivitySession>()))
                .Returns(Task.CompletedTask);

            // Act
            await _service.ProcessAsync(dto);

            // Assert
            _deviceServiceMock.Verify(d => d.CreateAsync(It.Is<Device>(dev => dev.Id == dto.Id)), Times.Once);
            _sessionServiceMock.Verify(s => s.AddAsync(It.Is<ActivitySession>(sess => sess.DeviceId == dto.Id)), Times.Once);
        }

        /// <summary>
        /// Проверяет, что если устройство существует, то создается только сессия, а новое устройство не создается.
        /// </summary>
        [Fact]
        public async Task ProcessAsync_DeviceExists_AddsSessionOnly()
        {
            // Arrange
            var dto = new DeviceActivityDto
            {
                Id = Guid.NewGuid(),
                Name = "Device1",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(1),
                Version = "1.0"
            };

            _deviceServiceMock
                .Setup(d => d.GetAsync(dto.Id))
                .ReturnsAsync(new Device { Id = dto.Id, Name = dto.Name, Version = dto.Version });

            _sessionServiceMock
                .Setup(s => s.AddAsync(It.IsAny<ActivitySession>()))
                .Returns(Task.CompletedTask);

            // Act
            await _service.ProcessAsync(dto);

            // Assert
            _deviceServiceMock.Verify(d => d.CreateAsync(It.IsAny<Device>()), Times.Never);
            _sessionServiceMock.Verify(s => s.AddAsync(It.Is<ActivitySession>(sess => sess.DeviceId == dto.Id)), Times.Once);
        }

        // Моки зависимостей сервиса
        private readonly Mock<IDeviceService> _deviceServiceMock = new();
        private readonly Mock<ISessionService> _sessionServiceMock = new();
        private readonly MonitoringService.Services.MonitoringService _service;
    }
}

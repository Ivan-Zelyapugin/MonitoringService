using Microsoft.OpenApi;
using Serilog;

namespace MonitoringService.Api.Extensions
{
    /// <summary>
    /// Класс с методами расширения для добавления дополнительной функциональности.
    /// </summary>
    public static class ApiExtensions
    {
        /// <summary>
        /// Добавляет базовые сервисы API: контроллеры, Swagger и CORS.
        /// </summary>
        /// <param name="services">Коллекция сервисов для конфигурации.</param>
        /// <returns>Возвращает ту же коллекцию сервисов с добавленными настройками.</returns>
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Monitoring Service API",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        /// <summary>
        /// Настраивает логирование приложения с использованием Serilog.
        /// </summary>
        /// <param name="builder">Объект сборки приложения для конфигурации хоста.</param>
        /// <returns>Возвращает тот же <see cref="WebApplicationBuilder"/> с настроенным Serilog.</returns>
        public static WebApplicationBuilder AddAppLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/monitoringservice.log",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7)
                .CreateLogger();

            builder.Host.UseSerilog();

            return builder;
        }
    }
}

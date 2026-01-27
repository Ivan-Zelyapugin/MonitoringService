using MonitoringService.Services.Exceptions;

namespace MonitoringService.Api.Middlewares
{
    /// <summary>
    /// Middleware обработки исключений.
    /// </summary>
    public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var logLevel = ex switch
                {
                    BadRequestException => LogLevel.Warning,
                    NotFoundException => LogLevel.Information,
                    _ => LogLevel.Error
                };

                logger.Log(logLevel, ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Обрабатывает исключение.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса и HTTP-ответа.</param>
        /// <param name="exception">Исключение.</param>
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                error = exception.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}

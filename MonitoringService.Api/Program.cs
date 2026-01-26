using MonitoringService.Api.Extensions;
using MonitoringService.Api.Middlewares;
using MonitoringService.DataAccess.Extensions;
using MonitoringService.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogging();

builder.Services
    .AddApi()
    .AddDapper()
    .AddRepositories()
    .MigrateDatabase(builder.Configuration)
    .AddServices();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

app.UseCors("default");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

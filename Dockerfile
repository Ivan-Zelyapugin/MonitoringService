FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MonitoringService.Api/MonitoringService.Api.csproj", "MonitoringService.Api/"]
COPY ["MonitoringService.Services/MonitoringService.Services.csproj", "MonitoringService.Services/"]
COPY ["MonitoringService.DataAccess/MonitoringService.DataAccess.csproj", "MonitoringService.DataAccess/"]
COPY ["MonitoringService.Models/MonitoringService.Models.csproj", "MonitoringService.Models/"]

RUN dotnet restore "./MonitoringService.Api/MonitoringService.Api.csproj"
COPY . .
WORKDIR "/src/MonitoringService.Api"
RUN dotnet build "./MonitoringService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MonitoringService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonitoringService.Api.dll"]
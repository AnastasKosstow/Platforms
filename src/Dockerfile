
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src/PlatformService.StartUp
COPY ["PlatformService.StartUp/PlatformService.StartUp.csproj", "PlatformService.StartUp/"]

RUN dotnet restore "PlatformService.StartUp/PlatformService.StartUp.csproj"
COPY . .
RUN dotnet build "PlatformService.StartUp/PlatformService.StartUp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatformService.StartUp/PlatformService.StartUp.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.StartUp.dll"]
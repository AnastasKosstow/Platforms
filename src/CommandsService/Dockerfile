
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src/CommandsService.StartUp
COPY ["CommandsService.StartUp/CommandsService.StartUp.csproj", "CommandsService.StartUp/"]

RUN dotnet restore "CommandsService.StartUp/CommandsService.StartUp.csproj"
COPY . .
RUN dotnet build "CommandsService.StartUp/CommandsService.StartUp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsService.StartUp/CommandsService.StartUp.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsService.StartUp.dll"]
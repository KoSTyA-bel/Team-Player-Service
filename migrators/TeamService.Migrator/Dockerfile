#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["migrators/TeamService.Migrator/TeamService.Migrator.csproj", "migrators/TeamService.Migrator/"]
COPY ["src/TeamService.DataAccess/TeamService.DataAccess.csproj", "src/TeamService.DataAccess/"]
COPY ["src/TeamService.BusinessLogic/TeamService.BusinessLogic.csproj", "src/TeamService.BusinessLogic/"]
RUN dotnet restore "migrators/TeamService.Migrator/TeamService.Migrator.csproj"
COPY . .
WORKDIR "/src/migrators/TeamService.Migrator"
RUN dotnet build "TeamService.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamService.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamService.Migrator.dll"]
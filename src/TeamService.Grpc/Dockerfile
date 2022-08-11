#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TeamService.Grpc/TeamService.Grpc.csproj", "src/TeamService.Grpc/"]
COPY ["src/TeamService.BusinessLogic/TeamService.BusinessLogic.csproj", "src/TeamService.BusinessLogic/"]
COPY ["src/TeamService.DataAccess/TeamService.DataAccess.csproj", "src/TeamService.DataAccess/"]
RUN dotnet restore "src/TeamService.Grpc/TeamService.Grpc.csproj"
COPY . .
WORKDIR "/src/src/TeamService.Grpc"
RUN dotnet build "TeamService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamService.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamService.Grpc.dll"]
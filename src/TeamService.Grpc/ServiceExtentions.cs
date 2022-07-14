using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.BusinessLogic.Services;
using TeamService.DataAccess.Contexts;
using TeamService.DataAccess.Repositories;

namespace TeamService.Grpc;

public static class ServiceExtentions
{
    public static IServiceCollection AddPlayerService(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Player>, PlayerRepository>();
        services.AddScoped<IService<Player>, PlayerService>();
        return services;
    }

    public static IServiceCollection AddTeamService(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Team>, TeamRepository>();
        services.AddScoped<IService<Team>, TeamService.BusinessLogic.Services.TeamService>();
        return services;
    }

    public static IServiceCollection AddTeamContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<TeamContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IDataContext, TeamDataContext>();
        return services;
    }
}

using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;
using TeamService.DataAccess.Repositories;
using TeamService.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

// insert into other method
builder.Services.AddDbContextPool<TeamContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Data")));
builder.Services.AddScoped<IDataContext, TeamDataContext>();
//

builder.Services.AddScoped<IRepository<Team>, TeamRepository>();
builder.Services.AddScoped<IRepository<Player>, PlayerRepository>();
builder.Services.AddScoped<IService<Team>, TeamService.BusinessLogic.Services.TeamService>();
builder.Services.AddScoped<IService<Player>, TeamService.BusinessLogic.Services.PlayerService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<TeamService.Grpc.Services.TeamService>();
app.MapGrpcService<TeamService.Grpc.Services.PlayerService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

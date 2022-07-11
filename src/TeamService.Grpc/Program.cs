using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;
using TeamService.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

// insert into other method
builder.Services.AddDbContextPool<TeamContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=Test;User Id=postgres;Password=kofein"));
builder.Services.AddScoped<IDataContext, TeamDataContext>();
//

builder.Services.AddScoped<IRepository<Team>, TeamRepository>();
builder.Services.AddScoped<IService<Team>, TeamService.BusinessLogic.Services.TeamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<TeamService.Grpc.Services.TeamService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

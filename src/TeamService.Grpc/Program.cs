using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;
using TeamService.DataAccess.Repositories;
using TeamService.Grpc;
using TeamService.Grpc.ValidationSettings;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddTeamContext(builder.Configuration.GetConnectionString("Data"));
builder.Services.AddPlayerService();
builder.Services.AddTeamService();

builder.Services.AddScoped<IValidator<Player>, PlayerValidator>();
builder.Services.AddScoped<IValidator<Team>, TeamValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<TeamService.Grpc.Services.TeamService>();
app.MapGrpcService<TeamService.Grpc.Services.PlayerService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

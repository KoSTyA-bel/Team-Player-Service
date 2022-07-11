using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.Grpc.Services;

public class TeamService : Proto.TeamService.TeamServiceBase
{
    private readonly ILogger<TeamService> _logger;
    private readonly IService<Team> _service;

    public TeamService(IService<Team> service, ILogger<TeamService> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override async Task<Proto.CreateTeamResponse> CreateTeam(Proto.CreateTeamRequest request, ServerCallContext context)
    {
        await _service.Create(new Team
        {
            Name = request.Name,
        });

        return new Proto.CreateTeamResponse();
    }

    public override Task<Proto.GetTeamResponse> GetTeam(Proto.GetTeamRequest request, ServerCallContext context)
    {
        if (!_service.TryGetById(Guid.Parse(request.Id), out Team team))
        {
            return Task.FromResult(new Proto.GetTeamResponse());
        }

        return Task.FromResult(new Proto.GetTeamResponse
        {
            Id = team.Id.ToString(),
            Name = team.Name,
        });
    }

    public override async Task<Proto.UpdateTeamResponse> UpdateTeam(Proto.UpdateTeamRequest request, ServerCallContext context)
    {
        var team = new Team
        {
            Id = Guid.Parse(request.Id),
            Name = request.Name,
        };

        await _service.Update(team);

        return new Proto.UpdateTeamResponse();
    }

    public override async Task<Proto.DeleteTeamResponse> DeleteTeam(Proto.DeleteTeamRequest request, ServerCallContext context)
    {
        await _service.Delete(Guid.Parse(request.Id));

        return new Proto.DeleteTeamResponse();
    }
}

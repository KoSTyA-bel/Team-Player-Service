using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using Service.Grpc;

namespace TeamService.Grpc.Services;

public class TeamService : Service.Grpc.TeamService.TeamServiceBase
{
    private readonly ILogger<TeamService> _logger;
    private readonly IService<Team> _service;

    public TeamService(IService<Team> service, ILogger<TeamService> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override async Task<CreateTeamResponse> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    {
        await _service.Create(new Team
        {
            Name = request.Name,
        });

        return new CreateTeamResponse();
    }

    public override Task<GetTeamResponse> GetTeam(GetTeamRequest request, ServerCallContext context)
    {
        if (!_service.TryGetById(Guid.Parse(request.Id), out Team team))
        {
            return Task.FromResult(new GetTeamResponse());
        }

        return Task.FromResult(new GetTeamResponse
        {
            Id = team.Id.ToString(),
            Name = team.Name,
        });
    }

    public override async Task<UpdateTeamResponse> UpdateTeam(UpdateTeamRequest request, ServerCallContext context)
    {
        var team = new Team
        {
            Id = Guid.Parse(request.Id),
            Name = request.Name,
        };

        await _service.Update(team);

        return new UpdateTeamResponse();
    }

    public override async Task<DeleteTeamResponse> DeleteTeam(DeleteTeamRequest request, ServerCallContext context)
    {
        await _service.Delete(Guid.Parse(request.Id));

        return new DeleteTeamResponse();
    }
}

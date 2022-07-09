using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TeamService.Grpc.Services;

public class TeamService : Proto.TeamService.TeamServiceBase
{
    private readonly ILogger<TeamService> _logger;

    public TeamService(ILogger<TeamService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override Task<Proto.CreateTeamResponse> CreateTeam(Proto.CreateTeamRequest request, ServerCallContext context)
    {
        return base.CreateTeam(request, context);
    }

    public override Task<Proto.GetTeamResponse> GetTeam(Proto.GetTeamRequest request, ServerCallContext context)
    {
        return base.GetTeam(request, context);
    }

    public override Task<Proto.UpdateTeamResponse> UpdateTeam(Proto.UpdateTeamRequest request, ServerCallContext context)
    {
        return base.UpdateTeam(request, context);
    }

    public override Task<Proto.DeleteTeamResponse> DeleteTeam(Proto.DeleteTeamRequest request, ServerCallContext context)
    {
        return base.DeleteTeam(request, context);
    }
}

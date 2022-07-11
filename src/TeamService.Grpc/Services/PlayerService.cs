using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using Service.Grpc;

namespace TeamService.Grpc.Services;

public class PlayerService : Service.Grpc.PlayerService.PlayerServiceBase
{
    private readonly ILogger<TeamService> _logger;
    private readonly IService<Player> _service;

    public PlayerService(ILogger<TeamService> logger, IService<Player> service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest request, ServerCallContext context)
    {
        await _service.Create(new Player
        {
            Name = request.Name,
            TeamId = Guid.Parse(request.Team),
        });

        return new CreatePlayerResponse();
    }

    public override Task<GetPlayerResponse> GetPlayer(GetPlayerRequest request, ServerCallContext context)
    {
        if (!_service.TryGetById(Guid.Parse(request.Id), out Player player))
        {
            return Task.FromResult(new GetPlayerResponse());
        }

        return Task.FromResult(new GetPlayerResponse
        {
            Id = player.Id.ToString(),
            Name = player.Name,
            Team = player.TeamId.ToString(),
        });
    }

    public override async Task<UpdatePlayerResponse> UpdatePlayer(UpdatePlayerRequest request, ServerCallContext context)
    {
        var player = new Player
        {
            Id = Guid.Parse(request.Id),
            Name = request.Name,
            TeamId = Guid.Parse(request.Team),
        };

        await _service.Update(player);

        return new UpdatePlayerResponse();
    }

    public override async Task<DeletePlayerResponse> DeletePlayer(DeletePlayerRequest request, ServerCallContext context)
    {
        await _service.Delete(Guid.Parse(request.Id));

        return new DeletePlayerResponse();
    }
}

using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using Service.Grpc;
using AutoMapper;
using FluentValidation;

namespace TeamService.Grpc.Services;

public class PlayerService : Service.Grpc.PlayerService.PlayerServiceBase
{
    private readonly ILogger<TeamService> _logger;
    private readonly IService<Player> _service;
    private readonly IMapper _mapper;
    private readonly IValidator<Player> _validator;

    public PlayerService(ILogger<TeamService> logger, IService<Player> service, IMapper mapper, IValidator<Player> validator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public override async Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"CreatePlayer executed. \r\nRequest: {request}.");

        var player = _mapper.Map<Player>(request);
        var validationResult = await _validator.ValidateAsync(player);

        if (validationResult.IsValid)
        {
            _logger.LogInformation($"Starting creating player. \r\nTeam: {player}");

            await _service.Create(player);

            _logger.LogInformation($"Player created successfully.");
        }

        return new CreatePlayerResponse();
    }

    public override Task<GetPlayerResponse> GetPlayer(GetPlayerRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"GetPlayer executed. \r\nRequest: {request}.");

        if (!_service.TryGetById(_mapper.Map<Guid>(request.Id), out Player player))
        {
            _logger.LogInformation($"Player not found.");

            return Task.FromResult(new GetPlayerResponse());
        }

        _logger.LogInformation($"Player is found.");

        return Task.FromResult(_mapper.Map<GetPlayerResponse>(player));
    }

    public override async Task<UpdatePlayerResponse> UpdatePlayer(UpdatePlayerRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Update executed. \r\nRequest: {request}.");

        var player = _mapper.Map<Player>(request);
        var validationResult = await _validator.ValidateAsync(player);

        if (validationResult.IsValid)
        {
            _logger.LogInformation($"Starting updating player. \r\nTeam: {player}");

            await _service.Update(player);

            _logger.LogInformation($"Player updated successfully.");
        }

        return new UpdatePlayerResponse();
    }

    public override async Task<DeletePlayerResponse> DeletePlayer(DeletePlayerRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"DeletePlayer executed. \r\nRequest: {request}.");

        await _service.Delete(_mapper.Map<Guid>(request.Id));

        _logger.LogInformation($"Player deleted successfully.");

        return new DeletePlayerResponse();
    }
}

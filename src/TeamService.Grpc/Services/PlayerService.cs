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
        var player = _mapper.Map<Player>(request);
        var validationResult = await _validator.ValidateAsync(player);

        if (validationResult.IsValid)
        {
            await _service.Create(player);
        }

        return new CreatePlayerResponse();
    }

    public override Task<GetPlayerResponse> GetPlayer(GetPlayerRequest request, ServerCallContext context)
    {
        if (!_service.TryGetById(_mapper.Map<Guid>(request.Id), out Player player))
        {
            return Task.FromResult(new GetPlayerResponse());
        }

        return Task.FromResult(_mapper.Map<GetPlayerResponse>(player));
    }

    public override async Task<UpdatePlayerResponse> UpdatePlayer(UpdatePlayerRequest request, ServerCallContext context)
    {
        var player = _mapper.Map<Player>(request);
        var validationResult = await _validator.ValidateAsync(player);

        if (validationResult.IsValid)
        {
            await _service.Update(player);
        }

        return new UpdatePlayerResponse();
    }

    public override async Task<DeletePlayerResponse> DeletePlayer(DeletePlayerRequest request, ServerCallContext context)
    {
        await _service.Delete(_mapper.Map<Guid>(request.Id));

        return new DeletePlayerResponse();
    }
}

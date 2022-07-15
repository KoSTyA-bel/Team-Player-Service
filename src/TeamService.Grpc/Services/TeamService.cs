using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using Service.Grpc;
using AutoMapper;
using FluentValidation;

namespace TeamService.Grpc.Services;

public class TeamService : Service.Grpc.TeamService.TeamServiceBase
{
    private readonly ILogger<TeamService> _logger;
    private readonly IService<Team> _service;
    private readonly IMapper _mapper;
    private readonly IValidator<Team> _validator;

    public TeamService(IService<Team> service, ILogger<TeamService> logger, IMapper mapper, IValidator<Team> validator)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public override async Task<CreateTeamResponse> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"CreateTeam executed. \r\nRequest: {request}.");

        var team = _mapper.Map<Team>(request);
        var validationResult = await _validator.ValidateAsync(team);

        if (validationResult.IsValid)
        {
            _logger.LogInformation($"Starting creating team. \r\nTeam: {team}");

            await _service.Create(team);

            _logger.LogInformation($"Team created successfully.");
        }

        return new CreateTeamResponse();
    }

    public override Task<GetTeamResponse> GetTeam(GetTeamRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"GetTeam executed. \r\nRequest: {request}.");

        if (!_service.TryGetById(_mapper.Map<Guid>(request.Id), out Team team))
        {
            _logger.LogInformation($"Team not found.");

            return Task.FromResult(new GetTeamResponse());
        }

        _logger.LogInformation($"Team if found.");

        return Task.FromResult(_mapper.Map<GetTeamResponse>(team));
    }

    public override async Task<UpdateTeamResponse> UpdateTeam(UpdateTeamRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"UpdateTeam executed. \r\nRequest: {request}.");

        var team = _mapper.Map<Team>(request);
        var validationResult = await _validator.ValidateAsync(team);

        if (validationResult.IsValid)
        {
            _logger.LogInformation($"Starting updating team. \r\nTeam: {team}");

            await _service.Update(team);

            _logger.LogInformation($"Team updated successfully.");
        }

        return new UpdateTeamResponse();
    }

    public override async Task<DeleteTeamResponse> DeleteTeam(DeleteTeamRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"DeleteTeam executed. \r\nRequest: {request}.");

        await _service.Delete(_mapper.Map<Guid>(request.Id));

        _logger.LogInformation("Team deleted successfully.");

        return new DeleteTeamResponse();
    }
}

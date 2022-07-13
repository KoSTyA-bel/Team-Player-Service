using AutoMapper;
using TeamService.BusinessLogic.Entities;
using Service.Grpc;

namespace TeamService.Grpc;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Team, GetTeamResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        CreateMap<GetTeamResponse, Team>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<CreateTeamRequest, Team>();
        CreateMap<UpdateTeamRequest, Team>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<Player, GetPlayerResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.TeamId.ToString()));
        CreateMap<CreatePlayerRequest, Player>()
            .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => Guid.Parse(src.Team)))
            .ForMember(dest => dest.Team, opt => opt.Ignore());
        CreateMap<UpdatePlayerRequest, Player>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => Guid.Parse(src.Team)))
            .ForMember(dest => dest.Team, opt => opt.Ignore());

        CreateMap<string, Guid>()
            .ConvertUsing(src => Guid.Parse(src));
        CreateMap<Guid, string>()
            .ConvertUsing(src => src.ToString());
    }
}

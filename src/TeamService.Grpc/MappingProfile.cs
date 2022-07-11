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
        CreateMap<string, Guid>()
            .ConvertUsing(src => Guid.Parse(src));
        CreateMap<Guid, string>()
            .ConvertUsing(src => src.ToString());
    }
}

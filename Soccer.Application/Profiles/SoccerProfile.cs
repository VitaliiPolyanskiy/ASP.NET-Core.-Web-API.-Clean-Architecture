using AutoMapper;
using Soccer.Application.DTO;
using Soccer.Domain.Entities;

namespace Soccer.Application.Profiles;

public class SoccerProfile : Profile
{
    public SoccerProfile()
    {
        CreateMap<Team, TeamDTO>();

        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team != null ? src.Team.Name : null));
    }
}
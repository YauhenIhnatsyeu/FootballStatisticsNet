using AutoMapper;
using FS.Core.Models;
using FS.Web.Api.DTOs;

namespace FS.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserToServerDTO, User>();
            CreateMap<User, UserToClientDTO>();

            CreateMap<LeagueTable, LeagueTableDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Code));
            CreateMap<Team, TeamDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Code));

            CreateMap<FanClubToServerDTO, FanClub>();
            CreateMap<FanClub, FanClubToClientDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UsersFanClub));
            CreateMap<UserFanClubToServerDTO, UserFanClub>();
            CreateMap<UserFanClub, UserFanClubToClientDTO>();
        }
    }
}
using AutoMapper;
using FS.Core.Models;
using FS.Web.Api.Controllers;
using FS.Web.Api.DTOs;

namespace FS.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserToServerDTO, User>();
            CreateMap<User, UserToClientDTO>();
            CreateMap<FunClub, FunClubToClientDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UsersFunClub));
            CreateMap<UserFunClubToServerDTO, UserFunClub>();
            CreateMap<UserFunClub, UserFunClubToClientDTO>();
        }
    }
}
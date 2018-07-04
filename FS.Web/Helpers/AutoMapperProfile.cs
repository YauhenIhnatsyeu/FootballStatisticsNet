using System.Collections.Generic;
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
            CreateMap<UserFunClub, UserFunClubToClientDTO>();
            CreateMap<ICollection<UserFunClub>, IEnumerable<UserFunClubToClientDTO>>();
            CreateMap<FunClub, FunClubToClientDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(fc => fc.UsersFunClub));
        }
    }
}
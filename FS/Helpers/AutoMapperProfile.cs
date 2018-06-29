using AutoMapper;
using FS.Api.DTOs;
using FS.Core.Models;

namespace FS.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserToServerDTO, User>();
            CreateMap<User, UserToClientDTO>();
            CreateMap<FunClub, FunClubToClientDTO>();
        }
    }
}
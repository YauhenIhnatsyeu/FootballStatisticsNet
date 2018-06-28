using AutoMapper;
using FS.Core.Models;
using FS.Dtos;

namespace FS.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserToServerDTO, User>();
            CreateMap<User, UserToClientDTO>();
        }
    }
}
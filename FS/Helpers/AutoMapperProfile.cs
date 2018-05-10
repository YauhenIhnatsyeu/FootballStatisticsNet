using AutoMapper;
using FS.Dtos;
using FS.Models;

namespace FS.Helpers {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
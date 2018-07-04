﻿using System.Collections.Generic;
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
            CreateMap<UserFunClub, UserFunClubToClientDTO>();
            CreateMap<ICollection<UserFunClub>, IEnumerable<UserFunClubToClientDTO>>();
            CreateMap<FunClub, FunClubToClientDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(fc => fc.UsersFunClub));
        }
    }
}
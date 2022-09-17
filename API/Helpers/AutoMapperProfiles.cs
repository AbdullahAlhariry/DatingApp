using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, memberDto>()
                .ForMember(dest=> dest.PhotoUrl,
                 opt =>
                 opt.MapFrom(src=>
                 src.Photos.FirstOrDefault(x=> x.IsMain).Url))
                .ForMember(dest=> dest.Age, opt =>
                opt.MapFrom(src =>
                src.DateOfBirthy.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
        }
    }
}
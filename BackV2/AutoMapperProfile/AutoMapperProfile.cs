using AutoMapper;
using Back.Data.Entities;
using BackV2.Controllers.Dto;
using BackV2.Data.Entities;

namespace BackV2.AutoMapperProfile
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<RaceDto, Race>();
            CreateMap<RaceDto, Race>().ReverseMap();
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}

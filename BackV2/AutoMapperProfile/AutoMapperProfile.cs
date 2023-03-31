using AutoMapper;
using Back.Data.Entities;
using BackV2.Controllers.Dto;

namespace BackV2.AutoMapperProfile
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Race, RaceDto>();
            CreateMap<Race, RaceDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Back.Data.Entities;
using BackV2.AutoMapperProfile;
using BackV2.Controllers.Dto;
using BackV2.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers.Mapping
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : BackV2.Controllers.Mapping.Controller<Race, EFCoreRaceRepository, RaceDto>
    {
        public RaceController(EFCoreRaceRepository repository, IMapper mapper, ILogger<RaceController> logger) : base(repository,mapper, logger) {}

    }
}

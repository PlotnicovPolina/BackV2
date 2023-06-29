using AutoMapper;
using Back.Data.Entities;
using BackV2.Controllers.Dto;
using BackV2.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using BackV2.Controllers.Mapping;

namespace Back.Controllers.Mapping
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : Controller<Race, EFCoreRaceRepository, RaceDto>
    {
        public RaceController(EFCoreRaceRepository repository, IMapper mapper, ILogger<RaceController> logger) : base(repository,mapper, logger) {}

        
    }
}

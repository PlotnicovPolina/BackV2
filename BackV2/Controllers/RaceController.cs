using Back.Data;
using Back.Data.Entities;
using BackV2.Controllers;
using BackV2.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : Controller<Race, EFCoreRaceRepository>
    {
        public RaceController(EFCoreRaceRepository repository) : base(repository) { 
        

        }
    }
}

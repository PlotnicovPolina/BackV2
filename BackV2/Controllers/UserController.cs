using AutoMapper;
using Back.Data.Entities;
using BackV2.Controllers.Dto;
using BackV2.Controllers.Mapping;
using BackV2.Data.Entities;
using BackV2.Data.Repositories;
using BackV2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller<User, EFCoreUserRepository, UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, EFCoreUserRepository repository, IMapper mapper, ILogger<UserController> logger) : base(repository, mapper, logger) 
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        [SwaggerOperation(
          Summary = "Block user ",
          OperationId = "user.block",
          Tags = new[] { "User" })
        ]
        public async Task<ActionResult<string>> Block(int userId, DateTime endLock)
        {
            var response = await _userService.Block(userId, endLock);

            return Ok(response);
        }

    }
}

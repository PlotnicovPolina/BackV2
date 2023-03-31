using AutoMapper;
using BackV2.Controllers.Dto;
using BackV2.Data;
using BackV2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackV2.Controllers.Mapping
{
    [ApiController]
    [Route("[controller]")]
    public abstract class Controller<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        public readonly IMapper _mapper;
        public Controller(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Return all ",
          OperationId = "comon.getRaceList",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
          Summary = "Return by id",
          OperationId = "common.getRaceById",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<TEntity>> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
         Summary = "Add new race",
         OperationId = "race.addRace",
         Tags = new[] { "Races" })
        ]
        public async Task<ActionResult<TEntity>> AddAsync([FromBody] TEntity entity)
        {
            await _repository.AddAsync(entity);        
            return Created($"/getById/?Id={entity.Id}", entity);
        }

        [HttpPut]
        [SwaggerOperation(
         Summary = "Update ",
         OperationId = "race.updateRace",
         Tags = new[] { "Races" })
       ]
        public async Task<ActionResult<TEntity>> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return NoContent();
        }


        [HttpDelete]
        [SwaggerOperation(
          Summary = "Delete",
          OperationId = "common.delete",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<TEntity>> DeleteAsync(int id)
        {
            var entity = await _repository.DeleteAsync(id);

            if (entity == null)
                return NotFound();

            return NoContent();
        }
    } 
}

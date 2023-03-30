using Azure;
using Back.Data.Entities;
using BackV2.Data;
using BackV2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace BackV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class Controller<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        public Controller(TRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Return list of race",
          OperationId = "race.getRaceList",
          Tags = new[] { "Races" })
        ]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
          Summary = "Return race by id",
          OperationId = "race.getRaceById",
          Tags = new[] { "Races" })
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
          Summary = "Delete race",
          OperationId = "race.deleteRace",
          Tags = new[] { "Races" })
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

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
    public abstract class Controller<TEntity, TRepository, TDto> : ControllerBase
        where TEntity : class, IEntity
        where TDto : class, IDto
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
          OperationId = "comon.getList",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<List<TDto>>> GetAllAsync()
        {
            var raceList = await _repository.GetAllAsync();
            var result = _mapper.Map<List<TDto>>(raceList);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
          Summary = "Return by id",
          OperationId = "common.getById",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<TDto>> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);

            if (result == null) return NotFound();

            var resultDto = _mapper.Map<TDto>(result);

            return Ok(resultDto);
        }

        [HttpPost]
        [SwaggerOperation(
         Summary = "Add",
         OperationId = "common.add",
         Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<TDto>> AddAsync([FromBody] TDto dto)
        {
            var result = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(result);
            await _repository.SaveAsync();

            return Created($"/getById/?Id={result.Id}", result);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(
         Summary = "Update ",
         OperationId = "common.update",
         Tags = new[] { "Common" })
       ]
        public async Task<ActionResult<TEntity>> UpdateAsync([FromBody] TDto dto,[FromRoute] int id)
        {
            var entity = await _repository.GetAsync(id);

            entity = _mapper.Map(dto, entity);

            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(
          Summary = "Delete",
          OperationId = "common.delete",
          Tags = new[] { "Common" })
        ]
        public async Task<ActionResult<TEntity>> DeleteAsync([FromRoute] int id)
        {
            var entity = await _repository.DeleteAsync(id);
            await _repository.SaveAsync();

            if (entity == null)
                return NotFound();

            return NoContent();
        }
    } 
}

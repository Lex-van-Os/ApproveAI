using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiBusiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ApproveAiApi.Controllers
{
    public class GenericController<TEntity> : ODataController where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository => _unitOfWork.GetRepository<TEntity>();


        public GenericController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWork = unitOfWorkFactory.Create();
        }

        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [EnableQuery]
        public async Task<SingleResult<TEntity>> Get([FromODataUri] long key)
        {
            dynamic item = await _repository.GetByIdAsync(key);
            return SingleResult.Create(item);
        }

        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(entity);

            return CreatedAtAction("Get", new { id = (entity as dynamic).Id }, entity);
        }

        public async Task<IActionResult> Put([FromODataUri] long id, [FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != (entity as dynamic).Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != (entity as dynamic).Id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
            try
            {
                await _repository.DeleteAsync(key);

                return NoContent();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

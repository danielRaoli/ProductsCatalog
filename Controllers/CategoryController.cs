using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateCategoryModel createView)
        {
            var category = await _service.Create(createView);
            if (category == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { category.Id }, category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorydto>>> GetAll()
        {
            var category = await _service.GetAll();
            return Ok(category);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorydto>> Get(int id)
        {
            var categorydto = await _service.Get(id);
            if (categorydto == null)
            {
                return NotFound();
            }
            return Ok(categorydto);
        }

        [HttpPut]
        public async Task<ActionResult<Categorydto>> Put(int id, Categorydto categorydto)
        {
            var categoryUpdated = await _service.Update(id, categorydto);
            if (categoryUpdated == null)
            {
                return BadRequest();
            }

            return Ok(categoryUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}

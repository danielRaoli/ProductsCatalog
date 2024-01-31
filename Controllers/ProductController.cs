using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateProductModel createView)
        {
            var product = await _service.CreateProduct(createView);
            if (product == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetProduct), new { product.Id }, product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Put(int id, ProductDto product)
        {
            var productUpdated = await _service.UpdateProduct(id, product);
            if (productUpdated == null)
            {
                return BadRequest();
            }

            return Ok(productUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteProduct(id);
            return NoContent();
        }

    }
}

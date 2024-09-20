using induccionef.Models;
using induccionef.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using induccionef.Pagination;

namespace induccionef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase{
        
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? page, 
            [FromQuery] int? pageSize,
            [FromQuery] string? search = null,
            [FromQuery] bool? active = null,
            [FromQuery] int? minStock = null,
            [FromQuery] DateTime? entryDate = null,
            [FromQuery] int? bodegaId = null

            )
        {
            var filteredProducts = await _productRepository.GetFilteredAsync(search, active, minStock, entryDate, bodegaId);

            // Número de página 
            int _page = page ?? 1;
            // Cantidad de registros por página
            int _pageSize = pageSize ?? 5;

            var paginationResult = PaginationResult.Paginate(filteredProducts, _page, _pageSize);

            return Ok(paginationResult);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product){
            
            if (product == null)
            {
                return BadRequest("Error");
            }

            await _productRepository.AddAsync(product);

            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product){

            if (id != product.ProductId)
            {
                return BadRequest("El id del producto no coincide con el id de la URL");
            }

           await _productRepository.Update(product);

            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id){
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null){
                return NotFound();
            }

            
            await _productRepository.DeleteAsync(id);

            return NoContent();
        }


        }
        
        
    }

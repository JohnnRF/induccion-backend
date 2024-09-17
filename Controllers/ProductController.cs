using induccionef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace induccionef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase{
        
        private readonly InduccionContext _context;

        public ProductController(InduccionContext context){
            _context = context;
        }
    
        //GET
        [HttpGet]
        public async Task<ActionResult<Product>> GetAll(){
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product){
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product){

            if (id != product.ProductId)
            {
                return BadRequest("El id del producto no coincide con el id de la URL");
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id){
            var product = await _context.Products.FindAsync(id);
            if (product == null){
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        }
        
        
    }

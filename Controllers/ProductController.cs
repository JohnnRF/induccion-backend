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
        public async Task<IActionResult> GetAll(
            [FromQuery] int? page, 
            [FromQuery] int? pageSize,
            [FromQuery] string? search = null,
            [FromQuery] bool? active = null,
            [FromQuery] int? minStock = null

            )
        {

            // Consulta base
            var query = _context.Products.AsQueryable();

            // Filtro busqueda por nombre
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));          
            }

            //  Filtro busqueda de productos activos o inactivos
            if (active.HasValue)
            {
                query = query.Where(p => p.Active == active.Value);
            }

            // Filtro busqueda de productos por mínimo stock
            if (minStock.HasValue)
            {
                query = query.Where(p => p.Stock >= minStock.Value);
            }

            // Total de registros después de aplicar los filtros
            int total_records = await query.CountAsync();

            // número de página 
            int _page = page ?? 1;
            // cantidad de registros por página
            int _pageSize = pageSize ?? 5;
            // calcular total de páginas
            int total_pages = (int)Math.Ceiling((decimal)total_records/_pageSize);

            // Paginación 
            // Obtener los productos para la página actual
            var products = await query
                .Skip((_page - 1) * _pageSize)
                .Take(_pageSize)
                .ToListAsync();

            // Respuesta con filtros y paginación
            return Ok(new {
                totalRecords = total_records,
                totalPages   = total_pages,
                currentPage  = _page,
                pageSize     = _pageSize,
                products
            });
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

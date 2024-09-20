using induccionef.Models;
using Microsoft.EntityFrameworkCore;

namespace induccionef.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(InduccionContext context) : base(context){ }

    public async  Task<IEnumerable<Product>> GetFilteredAsync(string search, bool? active, int? minStock)
    {
        var query = _context.Products.Include((x)=> x.bodega).AsQueryable();

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
        return await query.ToListAsync();
    }
}
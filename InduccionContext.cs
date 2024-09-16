using induccionef.Models;
using Microsoft.EntityFrameworkCore;

namespace induccionef;

public class InduccionContext : DbContext {
    public DbSet<Product> Products {get; set;}

    public InduccionContext(DbContextOptions<InduccionContext> options): base(options) {
        
    }
}
using induccionef.Models;
using Microsoft.EntityFrameworkCore;

namespace induccionef.Repositories;

public class BodegaRepository : Repository<Bodega>
{
    public BodegaRepository(InduccionContext context) : base(context)
    {
    }

}
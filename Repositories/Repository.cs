
using Microsoft.EntityFrameworkCore;

namespace induccionef.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly InduccionContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(InduccionContext context){
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) throw new Exception("Entity not found");
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return  await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetPagedAsync(int page, int pageSize)
    {
        return await _dbSet.Skip((page-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _context.SaveChangesAsync();
    }
}
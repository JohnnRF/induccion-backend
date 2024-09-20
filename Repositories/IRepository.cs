namespace induccionef.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task Update (TEntity entity);
    Task DeleteAsync (int id);
    Task<int> CountAsync ();
    Task<IEnumerable<TEntity>> GetPagedAsync (int page, int pageSize);
}
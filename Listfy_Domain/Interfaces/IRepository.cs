namespace Listfy_Domain.Interfaces;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task<T> GetByIdAsync(int id);
    Task<bool> SaveAsync();
}
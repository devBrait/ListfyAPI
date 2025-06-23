using Listfy_Domain.Interfaces;
using Listfy_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Listfy_Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void DeleteRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public async Task<T> GetByIdAsync(int id)
    {
        var user = await _context.Set<T>().FindAsync(id);

        return user ?? throw new Exception("Not found user with this id.");
    }
    public async Task<bool> SaveAsync() => (await _context.SaveChangesAsync()) > 0;
}
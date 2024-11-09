
using System.Text.Json.Serialization.Metadata;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> Create(T value)
    {
        await _appDbContext.Set<T>().AddAsync(value);
        int res = await _appDbContext.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> Delete(T value)
    {
        _appDbContext.Set<T>().Remove(value);
        int res = await _appDbContext.SaveChangesAsync();
        return res > 0;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> Update(T value)
    {
        _appDbContext.Set<T>().Update(value);
        int res = await _appDbContext.SaveChangesAsync();
        return res > 0;
    }
}
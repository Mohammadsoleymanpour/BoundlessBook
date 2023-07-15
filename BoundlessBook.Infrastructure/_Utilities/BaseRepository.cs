using System.Linq.Expressions;
using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.BaseRepository;
using BoundlessBook.Infrastructure.Ef.Persistent;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Infrastructure._Utilities;

public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly BoundlessBookContext _context;

    public BaseRepository(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<TEntity?> GetAsync(Guid id)
    {
      return  await _context.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<TEntity?> GetTracking(Guid id)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public async Task AddRange(ICollection<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Any(expression);
    }

    public TEntity? Get(Guid id)
    {
        return _context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); 
    }
}
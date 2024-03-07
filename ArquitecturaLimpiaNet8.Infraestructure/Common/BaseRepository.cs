using ArquitecturaLimpiaNet8.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArquitecturaLimpiaNet8.Infraestructure.Common;

public class BaseRepository<T>(ApplicationDbContext context) where T : class
{
    protected readonly ApplicationDbContext _context = context;

    public IQueryable<T> Queryable(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate).AsQueryable();

    public IQueryable<T> Queryable() => _context.Set<T>().AsQueryable();

    public void Save(T entity) => _context.Entry(entity).State = EntityState.Added;

    public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

    public void Remove(T entity) => _context.Entry(entity).State = EntityState.Deleted;
}

using System.Linq.Expressions;

namespace ArquitecturaLimpiaNet8.Infraestructure.Common;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Queryable(Expression<Func<T, bool>> predicate);

    IQueryable<T> Queryable();

    void Save(T entity);

    void Update(T entity);

    void Remove(T entity);
}

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Read.Infrastructure.Persistence
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Delete(object id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        T Find(object id);
    }
}

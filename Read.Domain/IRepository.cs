using System;
using System.Linq;
using System.Linq.Expressions;

namespace Read.Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        T Find(object id);
    }
}

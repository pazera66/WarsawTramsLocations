using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities;

namespace Interfaces
{
    public interface IReadRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> WithIncludes(IQueryable<T> query);
    }
}
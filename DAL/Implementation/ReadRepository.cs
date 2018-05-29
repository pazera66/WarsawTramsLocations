using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Implementation
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IBaseEntity
    {
        protected DatabaseContext.DatabaseContext context;
        internal DbSet<T> dbSet;

        public ReadRepository(DatabaseContext.DatabaseContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return WithIncludes(dbSet).AsNoTracking().ToList();
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return WithIncludes(dbSet).AsNoTracking().Where(predicate);
        }

        public virtual IQueryable<T> WithIncludes(IQueryable<T> query)
        {
            return query;
        }
    }
}

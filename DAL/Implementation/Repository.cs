using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Implementation
{
    public class Repository<T> : ReadRepository<T>, IRepository<T> where T: class, IBaseEntity
    {
        public Repository(DatabaseContext.DatabaseContext ctx) : base(ctx)
        {
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}

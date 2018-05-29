using Entities;

namespace Interfaces
{
    public interface IRepository<T> : IReadRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
    }
}
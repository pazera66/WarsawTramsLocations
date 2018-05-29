using System.Linq;
using Entities;

namespace Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> WithIncludes(IQueryable<User> query);
    }
}
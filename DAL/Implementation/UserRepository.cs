using System.Linq;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext.DatabaseContext ctx) : base(ctx)
        {
        }

        public override IQueryable<User> WithIncludes(IQueryable<User> query)
        {
            return query.Include(x => x.UserRole).ThenInclude(y => y.Role);
        }
    }
}

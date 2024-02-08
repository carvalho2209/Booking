using Booky.Domain.Users;

namespace Booky.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    /// <inheritdoc />
    public UserRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}
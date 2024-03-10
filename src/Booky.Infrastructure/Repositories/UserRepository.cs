using Booky.Domain.Users;

namespace Booky.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    /// <inheritdoc />
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public override void Add(User user)
    {
        foreach (var role in user.Roles)
        {
            DbContext.Attach(role);
        }

        DbContext.Add(user);
    }
}
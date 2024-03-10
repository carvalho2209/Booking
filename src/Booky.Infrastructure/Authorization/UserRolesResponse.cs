using Booky.Domain.Users;

namespace Booky.Infrastructure.Authorization;

public class UserRolesResponse
{
    public Guid UserId { get; init; }

    public List<Role> Roles { get; init; } = [];
}
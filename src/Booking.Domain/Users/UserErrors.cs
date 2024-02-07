using Booky.Domain.Abstractions;

namespace Booky.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "The User with the specified identifier was not found.");
}
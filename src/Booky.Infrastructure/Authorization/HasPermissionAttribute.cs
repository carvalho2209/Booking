using Microsoft.AspNetCore.Authorization;

namespace Booky.Infrastructure.Authorization;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}
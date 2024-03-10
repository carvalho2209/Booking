using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
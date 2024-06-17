using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Users.LoginUser;

public sealed record LogInUserCommand(
    string Email,
    string Password) : ICommand<AccessTokenResponse>;
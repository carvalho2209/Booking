using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Users;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;

using Booky.Domain.Abstractions;

namespace Booky.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid Id) : IDomainEvent;
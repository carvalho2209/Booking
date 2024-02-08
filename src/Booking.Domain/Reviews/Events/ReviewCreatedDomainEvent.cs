using Booky.Domain.Abstractions;

namespace Booky.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
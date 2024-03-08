using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid Id) : IDomainEvent;
using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid Id) : IDomainEvent;
using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid Id) : IDomainEvent;
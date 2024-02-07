using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
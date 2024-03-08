using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;
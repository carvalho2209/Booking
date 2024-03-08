using Booky.Domain.Abstractions;

namespace Booky.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid Id) : IDomainEvent;
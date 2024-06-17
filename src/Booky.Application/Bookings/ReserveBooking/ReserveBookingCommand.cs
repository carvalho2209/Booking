using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.ReserveBooking;

public sealed record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;

using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.CancelBooking;

public sealed record CancelBookingCommand(Guid BookingId) : ICommand;

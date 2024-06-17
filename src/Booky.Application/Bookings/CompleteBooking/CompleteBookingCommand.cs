using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.CompleteBooking;

public sealed record CompleteBookingCommand(Guid BookingId) : ICommand;

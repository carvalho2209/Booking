using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.ConfirmBooking;

public sealed record ConfirmBookingCommand(Guid BookingId) : ICommand;

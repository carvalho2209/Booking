using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(Guid BookingId) : ICommand;

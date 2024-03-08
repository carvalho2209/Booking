using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
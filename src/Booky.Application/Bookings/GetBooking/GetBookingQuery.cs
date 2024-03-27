using Booky.Application.Caching;

namespace Booky.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : ICacheQuery<BookingResponse>
{
    public string CacheKey => $"bookings-{BookingId}";

    public TimeSpan? Expiration => null;
}
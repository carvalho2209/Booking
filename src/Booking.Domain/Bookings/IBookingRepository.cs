using Booky.Domain.Apartments;

namespace Booky.Domain.Bookings;

public interface IBookingRepository
{
    Task<bool> IsOverLappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken);
    void Add(Booking booking);
}
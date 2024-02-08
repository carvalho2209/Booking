﻿using Booky.Domain.Apartments;
using Booky.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Booky.Infrastructure.Repositories;

internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    /// <inheritdoc />
    public BookingRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    private static readonly BookingStatus[] ActiveBookingStatus =
    [
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    ];

    public async Task<bool> IsOverlappingAsync(
        Apartment apartment, 
        DateRange duration,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(
                booking =>
                    booking.ApartmentId == apartment.Id &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    ActiveBookingStatus.Contains(booking.Status),
                cancellationToken);
    }
}
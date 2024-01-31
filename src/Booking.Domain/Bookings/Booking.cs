using Booking.Domain.Abstractions;
using Booking.Domain.Apartments;

namespace Booking.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc,
        DateTime? confirmedOnUtc,
        DateTime? rejectedOnUtc,
        DateTime? completedOnUtc,
        DateTime? cancelledOnUtc)
        : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
        ConfirmedOnUtc = confirmedOnUtc;
        RejectedOnUtc = rejectedOnUtc;
        CompletedOnUtc = completedOnUtc;
        CancelledOnUtc = cancelledOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }


}
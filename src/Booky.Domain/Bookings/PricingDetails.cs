using Booky.Domain.Shared;

namespace Booky.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod, 
    Money CleaningFee, 
    Money AmenitiesUpCharge, 
    Money TotalPrice);
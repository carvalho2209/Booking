using Booky.Domain.Abstractions;

namespace Booky.Domain.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new(
        "Apartment.NotFound",
        "The Apartment with the specified identifier was not found.");
}
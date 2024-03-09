using Booky.Domain.Abstractions;
using Booky.Domain.Shared;

namespace Booky.Domain.Apartments;

public sealed class Apartment : Entity
{
    private Apartment() { }

    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        DateTime? lastBookOnUtc,
        List<Amenity> amenities)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        LastBookOnUtc = lastBookOnUtc;
        Amenities = amenities;
    }

    public Name Name { get; private set; } = null!;
    public Description Description { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Money Price { get; private set; } = null!;
    public Money CleaningFee { get; private set; } = null!;
    public DateTime? LastBookOnUtc { get; internal set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
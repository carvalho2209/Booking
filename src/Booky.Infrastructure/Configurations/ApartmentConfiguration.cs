using Booky.Domain.Apartments;
using Booky.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booky.Infrastructure.Configurations;

public sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("apartments");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Address);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(desc => desc.Value, value => new Description(value));

        builder.OwnsOne(apart => apart.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(apart => apart.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
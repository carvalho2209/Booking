using Booky.Domain.Apartments;

namespace Booky.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    /// <inheritdoc />
    public ApartmentRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
using Booky.Domain.Reviews;

namespace Booky.Infrastructure.Repositories;

internal sealed class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
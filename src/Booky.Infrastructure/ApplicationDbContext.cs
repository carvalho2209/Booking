using Booky.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booky.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    /// <inheritdoc />
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
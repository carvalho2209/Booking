using Booking.Domain.Abstractions;

namespace Booking.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id)
        : base(id)
    {
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
}
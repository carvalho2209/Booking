using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;
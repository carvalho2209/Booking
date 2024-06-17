using Booky.Application.Bookings.CancelBooking;
using Booky.Application.Bookings.CompleteBooking;
using Booky.Application.Bookings.ConfirmBooking;
using Booky.Application.Bookings.GetBooking;
using Booky.Application.Bookings.RejectBooking;
using Booky.Application.Bookings.ReserveBooking;
using Booky.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Booky.Api.Controllers.Bookings;

public static class Bookings
{
    public static IEndpointRouteBuilder MapBookingEndPoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("bookings/{id}", GetBooking)
            .RequireAuthorization()
            .WithName(nameof(GetBooking));

        builder.MapPost("reserveBooking", ReserveBooking)
            .RequireAuthorization();

        builder.MapPost("completeBooking", CompleteBooking)
            .RequireAuthorization();

        builder.MapPost("confirmBooking", ConfirmBooking)
            .RequireAuthorization();

        builder.MapPost("rejectBooking", RejectBooking)
            .RequireAuthorization();

        builder.MapPost("cancelBooking", CancelBooking)
            .RequireAuthorization();

        return builder;
    }

    public static async Task<Results<Ok, BadRequest<Error>>> CancelBooking(
        CancelBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new CancelBookingCommand(request.BookingId);

        var result = await sender.Send(command, cancellationToken);

        return result.IsFailure
            ? TypedResults.BadRequest(result.Error)
            : TypedResults.Ok();
    }

    public static async Task<Results<Ok, BadRequest<Error>>> RejectBooking(
        RejectBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new RejectBookingCommand(request.BookingId);

        var result = await sender.Send(command, cancellationToken);

        return result.IsFailure
            ? TypedResults.BadRequest(result.Error)
            : TypedResults.Ok();
    }

    public static async Task<Results<Ok, BadRequest<Error>>> ConfirmBooking(
        ConfirmBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new ConfirmBookingCommand(request.BookingId);

        var result = await sender.Send(command, cancellationToken);

        return result.IsFailure
            ? TypedResults.BadRequest(result.Error)
            : TypedResults.Ok();
    }

    public static async Task<Results<Ok, BadRequest<Error>>> CompleteBooking(
        CompleteBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new CompleteBookingCommand(request.BookingId);

        var result = await sender.Send(command, cancellationToken);

        return result.IsFailure
            ? TypedResults.BadRequest(result.Error)
            : TypedResults.Ok();
    }

    public static async Task<Results<Ok<BookingResponse>, NotFound>> GetBooking(
        Guid id,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }

    public static async Task<Results<CreatedAtRoute<Guid>, BadRequest<Error>>> ReserveBooking(
        ReserveBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            request.ApartmentId,
            request.UserId,
            request.StartDate,
            request.EndDate);

        var result = await sender.Send(command, cancellationToken);

        return result.IsFailure
            ? TypedResults.BadRequest(result.Error)
            : TypedResults.CreatedAtRoute(result.Value, nameof(GetBooking), new { id = result.Value });
    }
}
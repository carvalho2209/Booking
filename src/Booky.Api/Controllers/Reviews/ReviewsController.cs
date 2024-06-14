﻿using Asp.Versioning;
using Booky.Application.Reviews.AddReview;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booky.Api.Controllers.Reviews;

[Authorize]
[ApiVersion(ApiVersions.V1)]
[ApiController]
[Route("api/v{version:apiVersion}/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly ISender _sender;

    public ReviewsController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> AddReview(AddReviewRequest request, CancellationToken cancellationToken)
    {
        var command = new AddReviewCommand(request.BookingId, request.Rating, request.Comment);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }
}

﻿using Microsoft.AspNetCore.OutputCaching;
using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Endpoints.Ratings;

public static class DeleteRatingsEndpoint
{
	public const string Name = "DeleteRating";
	public static IEndpointRouteBuilder MapDeleteRating(this IEndpointRouteBuilder app)
	{
		app.MapDelete(ApiEndpoints.Movies.DeleteRating, async(Guid id,
			HttpContext context, IRatingService ratingService, CancellationToken token) =>
		{
			var userId = context.GetUserId();
			var result = await ratingService.DeleteRatingAsync(id, userId!.Value, token);
			return result ? Results.Ok() : Results.NotFound();
		}).WithName(Name)
		.Produces<MovieResponse>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status404NotFound)
		.RequireAuthorization();

		return app;
	}
}

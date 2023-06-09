﻿using Microsoft.AspNetCore.OutputCaching;
using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Endpoints.Ratings;

public static class GetUserRatingsEndpoint
{
	public const string Name = "GetUserRatings";
	public static IEndpointRouteBuilder MapGetUserRatings(this IEndpointRouteBuilder app)
	{
		app.MapGet(ApiEndpoints.Ratings.GetUserRatings, async (
			HttpContext context, IRatingService ratingService, CancellationToken token) =>
		{
			var userId = context.GetUserId();
			var ratings = await ratingService.GetRatingsForUserAsync(userId!.Value, token);
			var ratingsResponse = ratings.MapToResponse();
			return TypedResults.Ok(ratingsResponse);
		}).WithName(Name)
		.Produces<MovieResponse>(StatusCodes.Status200OK)
		.RequireAuthorization();

		return app;
	}
}

using Movies.Api.Endpoints.Movies;

namespace Movies.Api.Endpoints.Ratings;

public static class RatingEndpointsExtensions
{
	public static IEndpointRouteBuilder MapRatingEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapRateMovie();
		app.MapGetUserRatings();
		app.MapDeleteRating();

		return app;
	}
}

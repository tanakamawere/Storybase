using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class GenreEndpoints
{
    public static IEndpointRouteBuilder MapGenreEndpoints(this IEndpointRouteBuilder app)
    {
        //Get genre by id
        app.MapGet(EndpointStrings.GetGenreById, async Task<Results<Ok<Genre>, BadRequest>> (IGenreRepository repository, int id) =>
        {
            var genre = await repository.GetByIdAsync(id);
            if (genre == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(genre);
        });
        //Get all genres
        app.MapGet(EndpointStrings.GetAllGenres, async Task<Results<Ok<IEnumerable<Genre>>, BadRequest>> (IGenreRepository repository) =>
        {
            var genres = await repository.GetAllAsync();
            return TypedResults.Ok(genres);
        });
        return app;
    }
}

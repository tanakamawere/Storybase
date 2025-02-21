using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Endpoints;

public static class GeneralEndpoints
{
    public static IEndpointRouteBuilder MapGeneralEndpoints(this IEndpointRouteBuilder app)
    {
        //Search
        app.MapGet(EndpointStrings.Search, async Task<Results<Ok<SearchDto>, BadRequest>> (IGeneralRepository repository, string query) =>
        {
            var search = await repository.SearchApiAsync(query);
            return TypedResults.Ok(search);
        });


        return app;
    }

}

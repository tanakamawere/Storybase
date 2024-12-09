using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Endpoints;

public static class LibraryEndpoints
{
    public static IEndpointRouteBuilder MapLibraryEndpoints(this IEndpointRouteBuilder app)
    {
        //Get user's library
        app.MapGet(EndpointStrings.GetLibrary, async Task<Results<Ok<LibraryDto>, BadRequest>> (ILibraryRepository repository, string authUserId) =>
        {
            var library = await repository.LibraryDto(authUserId);
            return TypedResults.Ok(library);
        });

        return app;
    }
}
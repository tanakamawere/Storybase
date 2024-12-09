using Storybase.Core.Interfaces;
using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Core.DTOs;

namespace StorybaseApi.Endpoints;

public static class BookmarkEndpoints
{
    public static IEndpointRouteBuilder MapBookmarkEndpoints(this IEndpointRouteBuilder app)
    {

        //Get bookmark by id
        app.MapGet(EndpointStrings.GetBookmarkById, async Task<Results<Ok<Bookmark>, BadRequest>> (IBookmarkRepository repository, int id) =>
        {
            var bookmark = await repository.GetByIdAsync(id);
            if (bookmark == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(bookmark);
        });
        //Create a new chapter
        app.MapPost(EndpointStrings.CreateBookmark, async Task<Results<Ok<string>, BadRequest>> (IBookmarkRepository repository, BookmarkDto createBookmark) =>
        {
            await repository.AddBookmarkDto(createBookmark);
            return TypedResults.Ok("Bookmark created successfully");
        });
        //Update a chapter
        app.MapPut(EndpointStrings.UpdateBookmark, async Task<Results<Ok<string>, BadRequest>> (IBookmarkRepository repository, Bookmark updateBookmark) =>
        {
            await repository.UpdateAsync(updateBookmark);
            return TypedResults.Ok("Bookmark updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeleteBookmark, async Task<Results<Ok<string>, BadRequest>> (IBookmarkRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Bookmark deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchBookmarks, async Task<Results<Ok<IEnumerable<Bookmark>>, BadRequest>> (IBookmarkRepository repository, string query) =>
        {
            var bookmarks = await repository.SearchAsync(query);
            return TypedResults.Ok(bookmarks);
        });


        return app;
    }
}

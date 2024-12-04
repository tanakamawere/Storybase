using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class ChapterEndpoints
{
    public static IEndpointRouteBuilder MapChapterEndpoints(this IEndpointRouteBuilder app)
    {
        //Get chapter by id
        app.MapGet(EndpointStrings.GetChapterById, async Task<Results<Ok<Chapter>, BadRequest>> (IRepository<Chapter> repository, int id) =>
        {
            var chapter = await repository.GetByIdAsync(id);
            if (chapter == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(chapter);
        });

        //Create a new chapter
        app.MapPost(EndpointStrings.CreateChapter, async Task<Results<Ok<string>, BadRequest>> (IRepository<Chapter> repository, Chapter createChapter) =>
        {
            await repository.AddAsync(createChapter);
            return TypedResults.Ok("Chapter created successfully");
        });
        //Update a chapter
        app.MapPut(EndpointStrings.UpdateChapter, async Task<Results<Ok<string>, BadRequest>> (IRepository<Chapter> repository, Chapter updateChapter) =>
        {
            await repository.UpdateAsync(updateChapter);
            return TypedResults.Ok("Chapter updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeleteChapter, async Task<Results<Ok<string>, BadRequest>> (IRepository<Chapter> repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Chapter deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchChapters, async Task<Results<Ok<IEnumerable<Chapter>>, BadRequest>> (IRepository<Chapter> repository, string query) =>
        {
            var chapters = await repository.SearchAsync(query);
            return TypedResults.Ok(chapters);
        });

        return app;
    }
}

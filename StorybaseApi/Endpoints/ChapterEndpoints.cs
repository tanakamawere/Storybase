namespace StorybaseApi.Endpoints;

public static class ChapterEndpoints
{
    public static IEndpointRouteBuilder MapChapterEndpoints(this IEndpointRouteBuilder app)
    {
        //Get chapter by id
        app.MapGet(EndpointStrings.GetChapterById, async Task<Results<Ok<Chapter>, BadRequest>> (AppDbContext context, int id) =>
        {
            var chapter = await context.Chapters.FirstOrDefaultAsync(c => c.Id == id);

            if (chapter == null)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.Ok(chapter);
        });

        //Create a new chapter
        app.MapPost(EndpointStrings.CreateChapter, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, Chapter createChapter) =>
        {
            var chapter = new Chapter
            {
                Title = createChapter.Title,
                Content = createChapter.Content,
                DatePosted = DateTime.UtcNow,
                BookId = createChapter.BookId
            };

            context.Chapters.Add(chapter);
            await context.SaveChangesAsync();

            return TypedResults.Ok("Chapter created successfully");
        });

        //Update a chapter
        app.MapPut(EndpointStrings.UpdateChapter, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, Chapter updateChapter) =>
        {
            var chapter = await context.Chapters.FirstOrDefaultAsync(c => c.Id == updateChapter.Id);

            if (chapter == null)
            {
                return TypedResults.BadRequest();
            }

            chapter.Title = updateChapter.Title;
            chapter.Content = updateChapter.Content;
            chapter.DatePosted = DateTime.UtcNow;
            chapter.BookId = updateChapter.BookId;

            await context.SaveChangesAsync();

            return TypedResults.Ok("Chapter updated successfully");
        });

        //Delete a chapter
        app.MapDelete(EndpointStrings.DeleteChapter, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, int id) =>
        {
            var chapter = await context.Chapters.FirstOrDefaultAsync(c => c.Id == id);

            if (chapter == null)
            {
                return TypedResults.BadRequest();
            }

            context.Chapters.Remove(chapter);
            await context.SaveChangesAsync();

            return TypedResults.Ok("Chapter deleted successfully");
        });

        //Search for chapter
        app.MapGet(EndpointStrings.SearchChapters, async Task<Results<Ok<List<Chapter>>, BadRequest>> (AppDbContext context, string query) =>
        {
            var chapters = await context.Chapters.Where(c => c.Title.Contains(query)).ToListAsync();

            if (chapters == null)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.Ok(chapters);
        });

        return app;
    }
}

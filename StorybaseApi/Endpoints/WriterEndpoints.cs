namespace StorybaseApi.Endpoints
{
    public static class WriterEndpoints
    {
        public static IEndpointRouteBuilder MapWriterEndpoints(this IEndpointRouteBuilder app)
        {
            //Search for writers
            app.MapGet(EndpointStrings.SearchWriters, async Task<Results<Ok<List<Writer>>, BadRequest>> (AppDbContext context, string query) =>
            {
                var writers = await context.Writers.Where(w => w.Name.Contains(query)).ToListAsync();

                return TypedResults.Ok(writers);
            });

            //Get all books by a writer
            app.MapGet(EndpointStrings.GetWriterBooks, async Task<Results<Ok<List<Book>>, BadRequest>> (AppDbContext context, int writerId) =>
            {
                var books = await context.Books.Where(b => b.Writer.Id == writerId).ToListAsync();

                return TypedResults.Ok(books);
            });

            //Get all chapters by a writer
            app.MapGet(EndpointStrings.GetWriterChapters, async Task<Results<Ok<List<Chapter>>, BadRequest>> (AppDbContext context, int writerId) =>
            {
                var chapters = await context.Chapters.Where(c => c.Book.Writer.Id == writerId).ToListAsync();

                return TypedResults.Ok(chapters);
            });

            //Create a writer
            app.MapPost(EndpointStrings.CreateWriterSignup, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, Writer writer) =>
            {
                context.Writers.Add(writer);
                await context.SaveChangesAsync();

                return TypedResults.Ok("Writer created successfully");
            });

            //Get the writer profile
            app.MapGet(EndpointStrings.GetWriterProfile, async Task<Results<Ok<Writer>, BadRequest>> (AppDbContext context, int writerId) =>
            {
                var writer = await context.Writers
                .Include(x => x.Books)
                .FirstOrDefaultAsync(w => w.Id == writerId);

                return TypedResults.Ok(writer);
            });

            return app;
        }
    }
}

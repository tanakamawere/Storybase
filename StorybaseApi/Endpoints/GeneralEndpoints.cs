namespace StorybaseApi.Endpoints;

public static class GeneralEndpoints
{
    public static IEndpointRouteBuilder MapGeneralEndpoints(this IEndpointRouteBuilder app)
    {

        //Endpoint to search from books, writers and chapters
        app.MapGet(EndpointStrings.GetSearch, async Task<Results<Ok<SearchResults>, BadRequest>> (AppDbContext context, string query) =>
        {
            var books = await context.Books.Where(b => b.Title.Contains(query) || b.Summary.Contains(query))
            .ToListAsync();

            var writers = await context.Writers
                .Where(w => w.Name.Contains(query) || w.UserName.Contains(query))
                .ToListAsync();

            var searchResults = new SearchResults
            {
                SearchTerm = query,
                Books = books,
                Writers = writers
            };

            return TypedResults.Ok(searchResults);
        });

        return app;
    }
}

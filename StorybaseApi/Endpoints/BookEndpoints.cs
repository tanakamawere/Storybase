namespace StorybaseApi.Endpoints;

public static class BookEndpoints
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
                    //Create a new book
        app.MapPost(EndpointStrings.CreateBook, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, Book createBook) =>
        {
            var book = new Book
            {
                Title = createBook.Title,
                Writer = createBook.Writer,
                Genre = createBook.Genre,
                CoverImageUrl = createBook.CoverImageUrl,
                Summary = createBook.Summary,
                Price = createBook.Price
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();

            return TypedResults.Ok("Book created successfully");
        });

        //Get all books
        app.MapGet(EndpointStrings.GetBooks, async (AppDbContext context) =>
        {
            var books = await context.Books.Include(x => x.Writer).ToListAsync();

            return books;
        });

        //Get book by id
        app.MapGet(EndpointStrings.GetBookById, async Task<Results<Ok<Book>, BadRequest>> (AppDbContext context, int id) =>
        {
            var book = await context.Books
                .Include(x => x.Chapters)
                .Include(x => x.Writer)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.Ok(book);
        });

        //Update book by id
        app.MapPut(EndpointStrings.UpdateBook, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, Book updateBook) =>
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == updateBook.Id);

            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            book.Title = updateBook.Title;
            book.Writer = updateBook.Writer;
            book.Genre = updateBook.Genre;
            book.CoverImageUrl = updateBook.CoverImageUrl;
            book.Summary = updateBook.Summary;
            book.Price = updateBook.Price;

            await context.SaveChangesAsync();

            return TypedResults.Ok("Book updated successfully");
        });

        //Delete book by id
        app.MapDelete(EndpointStrings.DeleteBook, async Task<Results<Ok<string>, BadRequest>> (AppDbContext context, int id) =>
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return TypedResults.Ok("Book deleted successfully");
        });

        //Get all chapters of a book
        app.MapGet(EndpointStrings.GetBookChapters, async Task<Results<Ok<List<Chapter>>, BadRequest>> (AppDbContext context, int bookId) =>
        {
            var book = await context.Books.Include(b => b.Chapters).FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.Ok(book.Chapters.ToList());
        });

        //Search for books
        app.MapGet(EndpointStrings.SearchBooks, async Task<Results<Ok<List<Book>>, BadRequest>> (AppDbContext context, string query) =>
        {
            var books = await context.Books.Where(b => b.Title.Contains(query)).ToListAsync();

            return TypedResults.Ok(books);
        });

        return app;
    }
}

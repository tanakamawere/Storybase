namespace StorybaseLibrary.Services;

public class EndpointStrings
{
    //Auth Endpoints
    public const string RegisterUser = "api/auth/register";
    // User Login
    public const string LoginUser = "api/auth/login";

    //Book Endpoints
    public const string GetBooks = "api/books";
    public const string GetBookById = "api/books/getbook";
    public const string CreateBook = "api/books/create";
    public const string UpdateBook = "api/books/update";
    public const string DeleteBook = "api/books/delete";
    //Endpoint to search for book
    public const string SearchBooks = "api/books/search";

    //Get all chapters from a book
    public const string GetBookChapters = "api/books/chapters";

    //Chapter Endpoints
    public const string GetChapterById = "api/chapters/getchapter";
    public const string CreateChapter = "api/chapters/create";
    public const string UpdateChapter = "api/chapters/update";
    public const string DeleteChapter = "api/chapters/delete";
    public const string SearchChapters = "api/chapters/search";

    //Writer endpoints
    public const string GetWriterBooks = "api/writer/books";
    public const string GetWriterChapters = "api/writer/chapters";
    public const string CreateWriterSignup = "api/writer/signup";
    public const string SearchWriters = "api/writer/search";
    public const string GetWriterProfile = "api/writer/profile";
}

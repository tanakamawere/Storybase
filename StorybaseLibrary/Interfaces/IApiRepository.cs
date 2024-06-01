using StorybaseLibrary.Models;

namespace StorybaseLibrary.Interfaces;

public interface IApiRepository
{// Auth Endpoints
    Task RegisterUserAsync(RegisterUserDto user);
    //Returns Jwt
    Task<string> LoginUserAsync(LoginUserRequest user);

    // Book Endpoints
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task CreateBookAsync(Book createBook);
    Task UpdateBookAsync(Book updateBook);
    Task DeleteBookAsync(int id);
    Task<IEnumerable<Book>> SearchBooksAsync(string query);

    // Book Chapters
    Task<IEnumerable<Chapter>> GetBookChaptersAsync(int bookId);

    // Chapter Endpoints
    Task<Chapter> GetChapterByIdAsync(int id);
    Task CreateChapterAsync(Chapter createChapter);
    Task UpdateChapterAsync(Chapter updateChapter);
    Task DeleteChapterAsync(int id);
    Task<IEnumerable<Chapter>> SearchChaptersAsync(string query);

    // Writer Endpoints
    Task<IEnumerable<Book>> GetWriterBooksAsync(int writerId);
    Task<IEnumerable<Chapter>> GetWriterChaptersAsync(int writerId);
    Task CreateWriterSignupAsync(Writer writer);
    Task<IEnumerable<Writer>> SearchWritersAsync(string query);
    Task<Writer> GetWriterProfileAsync(int writerId);
}

using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Models;
using StorybaseLibrary.Services;
using System.Net.Http.Json;
using System.Diagnostics;

namespace StorybaseLibrary.Repositories;

public class ApiRepository : IApiRepository
{
    private readonly HttpClient httpClient;
    public ApiRepository(IHttpClientFactory httpClientFactory)
    {
        try
        {
            httpClient = httpClientFactory.CreateClient("StorybaseApiClient");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    // Auth Endpoints
    public async Task<LoginResponse> RegisterUserAsync(RegisterUserDto user)
    {
        var response = await httpClient.PostAsJsonAsync(EndpointStrings.RegisterUser, user);
        return await response.Content.ReadFromJsonAsync<LoginResponse>(); 
    }

    public async Task<LoginResponse> LoginUserAsync(LoginUserRequest user)
    {
        var response = await httpClient.PostAsJsonAsync(EndpointStrings.LoginUser, user);
        return await response.Content.ReadFromJsonAsync<LoginResponse>();
    }

    // Book Endpoints
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        Debug.WriteLine($"Getting books: {EndpointStrings.GetBooks}");

        var response =  await httpClient.GetFromJsonAsync<IEnumerable<Book>>(EndpointStrings.GetBooks);
        return response;
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Book>($"{EndpointStrings.GetBookById}?{nameof(id)}={id}");
    }

    public async Task CreateBookAsync(Book book)
    {
        await httpClient.PostAsJsonAsync(EndpointStrings.CreateBook, book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        await httpClient.PutAsJsonAsync($"{EndpointStrings.UpdateBook}", book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await httpClient.DeleteAsync($"{EndpointStrings.DeleteBook}?{nameof(id)}={id}");
    }

    public async Task<IEnumerable<Book>> SearchBooksAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Book>>($"{EndpointStrings.SearchBooks}?query={query}");
    }

    // Book Chapters
    public async Task<IEnumerable<Chapter>> GetBookChaptersAsync(int bookId)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Chapter>>($"{EndpointStrings.GetBookChapters}?{nameof(bookId)}={bookId}");
    }

    // Chapter Endpoints
    public async Task<Chapter> GetChapterByIdAsync(int chapterId)
    {
        return await httpClient.GetFromJsonAsync<Chapter>($"{EndpointStrings.GetChapterById}?{nameof(chapterId)}={chapterId}");
    }

    public async Task CreateChapterAsync(Chapter chapter)
    {
        await httpClient.PostAsJsonAsync(EndpointStrings.CreateChapter, chapter);
    }

    public async Task UpdateChapterAsync(Chapter chapter)
    {
        await httpClient.PutAsJsonAsync($"{EndpointStrings.UpdateChapter}", chapter);
    }

    public async Task DeleteChapterAsync(int chapterId)
    {
        await httpClient.DeleteAsync($"{EndpointStrings.DeleteChapter}?{nameof(chapterId)}={chapterId}");
    }

    public async Task<IEnumerable<Chapter>> SearchChaptersAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Chapter>>($"{EndpointStrings.SearchChapters}?query={query}");
    }

    // Writer Endpoints
    public async Task<IEnumerable<Book>> GetWriterBooksAsync(int writerId)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Book>>($"{EndpointStrings.GetWriterBooks}?{nameof(writerId)}={writerId}");
    }

    public async Task<IEnumerable<Chapter>> GetWriterChaptersAsync(int writerId)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Chapter>>($"{EndpointStrings.GetWriterChapters}?{nameof(writerId)}={writerId}");
    }

    public async Task<bool> CreateWriterSignupAsync(WriterDto writer)
    {   
        var response = await httpClient.PostAsJsonAsync(EndpointStrings.CreateWriterSignup, writer);

        if (response.IsSuccessStatusCode)
        {
            // Handle successful response (e.g., parse JSON data if necessary)
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Question posted successfully! Response: {responseContent}");
            return true; // Indicate successful posting
        }
        else
        {
            // Handle failed response with proper error handling
            Console.WriteLine($"Error posting question: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            return false; // Indicate posting failed
        }
    }

    public async Task<IEnumerable<Writer>> SearchWritersAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Writer>>($"{EndpointStrings.SearchWriters}?query={query}");
    }

    public async Task<Writer> GetWriterProfileAsync(int writerId)
    {
        return await httpClient.GetFromJsonAsync<Writer>($"{EndpointStrings.GetWriterProfile}?{nameof(writerId)}={writerId}");
    }

    public async Task<SearchResults> SearchAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<SearchResults>($"{EndpointStrings.GetSearch}?query={query}");
    }
}

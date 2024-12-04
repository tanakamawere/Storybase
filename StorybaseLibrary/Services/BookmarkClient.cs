using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class BookmarkClient
{
    private readonly IApiClient _apiClient;

    public BookmarkClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Bookmark> GetBookmarkByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Bookmark>($"{EndpointStrings.GetBookmarkById}?id={id}");
    }

    public async Task<Bookmark> AddBookmarkAsync(Bookmark Bookmark)
    {
        return await _apiClient.PostAsync<Bookmark>($"{EndpointStrings.CreateBookmark}", Bookmark);
    }

    //Delete Bookmark
    public async Task<Bookmark> DeleteBookmarkAsync(int id)
    {
        return await _apiClient.DeleteAsync<Bookmark>($"{EndpointStrings.DeleteBookmark}?id={id}");
    }
    //update Bookmark
    public async Task<Bookmark> UpdateBookmarkAsync(Bookmark Bookmark)
    {
        return await _apiClient.PutAsync<Bookmark>($"{EndpointStrings.UpdateBookmark}", Bookmark);
    }
    //search Bookmark
    public async Task<IEnumerable<Bookmark>> SearchBookmarksAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Bookmark>>($"{EndpointStrings.SearchBookmarks}?query={search}");
    }
}


using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class BookmarkClient
{
    private readonly IApiClient _apiClient;

    public BookmarkClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<Bookmark>> GetBookmarkByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Bookmark>($"{EndpointStrings.GetBookmarkById}?id={id}");
    }

    public async Task<ApiResponse<string>> AddBookmarkAsync(BookmarkDto Bookmark)
    {
        return await _apiClient.PostAsync<string>($"{EndpointStrings.CreateBookmark}", Bookmark);
    }

    //Delete Bookmark
    public async Task<ApiResponse<string>> DeleteBookmarkAsync(int id)
    {
        return await _apiClient.DeleteAsync<string>($"{EndpointStrings.DeleteBookmark}?id={id}");
    }
    //update Bookmark
    public async Task<ApiResponse<string>> UpdateBookmarkAsync(Bookmark Bookmark)
    {
        return await _apiClient.PutAsync<string>($"{EndpointStrings.UpdateBookmark}", Bookmark);
    }
    //search Bookmark
    public async Task<ApiResponse<IEnumerable<Bookmark>>> SearchBookmarksAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Bookmark>>($"{EndpointStrings.SearchBookmarks}?query={search}");
    }
}


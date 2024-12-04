using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class ChapterClient
{
    private readonly IApiClient _apiClient;

    public ChapterClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Chapter> GetChapterByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Chapter>($"{EndpointStrings.GetChapterById}?id={id}");
    }

    public async Task<Chapter> AddChapterAsync(Chapter Chapter)
    {
        return await _apiClient.PostAsync<Chapter>($"{EndpointStrings.CreateChapter}", Chapter);
    }

    //Delete Chapter
    public async Task<Chapter> DeleteChapterAsync(int id)
    {
        return await _apiClient.DeleteAsync<Chapter>($"{EndpointStrings.DeleteChapter}?id={id}");
    }
    //update Chapter
    public async Task<Chapter> UpdateChapterAsync(Chapter Chapter)
    {
        return await _apiClient.PutAsync<Chapter>($"{EndpointStrings.UpdateChapter}", Chapter);
    }
    //search Chapter
    public async Task<IEnumerable<Chapter>> SearchChaptersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Chapter>>($"{EndpointStrings.SearchChapters}?query={search}");
    }
}


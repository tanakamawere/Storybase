using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;
using Storybase.Application.Models;

namespace Storybase.Application.Services;

public class ReadingProgressClient
{
    private readonly IApiClient _apiClient;

    public ReadingProgressClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<ReadingProgress>> GetReadingProgressByIdAsync(int id)
    {
        return await _apiClient.GetAsync<ReadingProgress>($"{EndpointStrings.GetReadingProgressById}?id={id}");
    }

    public async Task<ApiResponse<ReadingProgress>> AddReadingProgressAsync(ReadingProgress readingProgress)
    {
        return await _apiClient.PostAsync<ReadingProgress>($"{EndpointStrings.CreateReadingProgress}", readingProgress);
    }

    public async Task<ApiResponse<ReadingProgress>> DeleteReadingProgressAsync(int id)
    {
        return await _apiClient.DeleteAsync<ReadingProgress>($"{EndpointStrings.DeleteReadingProgress}?id={id}");
    }

    public async Task<ApiResponse<ReadingProgress>> UpdateReadingProgressAsync(ReadingProgress readingProgress)
    {
        return await _apiClient.PutAsync<ReadingProgress>($"{EndpointStrings.UpdateReadingProgress}", readingProgress);
    }

    public async Task<ApiResponse<IEnumerable<ReadingProgress>>> SearchReadingProgresssAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<ReadingProgress>>($"{EndpointStrings.SearchReadingProgresss}?query={search}");
    }

    public async Task<ApiResponse<IEnumerable<ReadingProgress>>> GetReadingProgresssAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<ReadingProgress>>(EndpointStrings.GetAllReadingProgresss);
    }
}

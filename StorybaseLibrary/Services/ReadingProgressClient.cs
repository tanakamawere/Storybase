using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class ReadingProgressClient
{
    private readonly IApiClient _apiClient;

    public ReadingProgressClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ReadingProgress> GetReadingProgressByIdAsync(int id)
    {
        return await _apiClient.GetAsync<ReadingProgress>($"{EndpointStrings.GetReadingProgressById}?id={id}");
    }

    public async Task<ReadingProgress> AddReadingProgressAsync(ReadingProgress ReadingProgress)
    {
        return await _apiClient.PostAsync<ReadingProgress>($"{EndpointStrings.CreateReadingProgress}", ReadingProgress);
    }

    //Delete ReadingProgress
    public async Task<ReadingProgress> DeleteReadingProgressAsync(int id)
    {
        return await _apiClient.DeleteAsync<ReadingProgress>($"{EndpointStrings.DeleteReadingProgress}?id={id}");
    }
    //update ReadingProgress
    public async Task<ReadingProgress> UpdateReadingProgressAsync(ReadingProgress ReadingProgress)
    {
        return await _apiClient.PutAsync<ReadingProgress>($"{EndpointStrings.UpdateReadingProgress}", ReadingProgress);
    }
    //search ReadingProgress
    public async Task<IEnumerable<ReadingProgress>> SearchReadingProgresssAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<ReadingProgress>>($"{EndpointStrings.SearchReadingProgresss}?query={search}");
    }
    //Get all ReadingProgresss
    public async Task<IEnumerable<ReadingProgress>> GetReadingProgresssAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<ReadingProgress>>(EndpointStrings.GetAllReadingProgresss);
    }
}

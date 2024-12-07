using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.Models;

namespace Storybase.Application.Services;

public class GenresClient
{
    private readonly IApiClient _apiClient;
    public GenresClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<IEnumerable<Genre>>> GetAllGenresAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<Genre>>(EndpointStrings.GetAllGenres);
    }

    public async Task<ApiResponse<Genre>> GetGenreByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Genre>($"{EndpointStrings.GetGenreById}?id={id}");
    }
}

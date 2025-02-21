using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class GeneralClient
{
    private readonly IApiClient apiClient;

    public GeneralClient(IApiClient client)
    {
        apiClient = client;
    }

    public async Task<ApiResponse<SearchDto>> SearchAsync(string query)
    {
        return await apiClient.GetAsync<SearchDto>($"{EndpointStrings.Search}?query={query}");
    }
}

using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class LibraryClient
{
    private readonly IApiClient apiClient;
    public LibraryClient(IApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<ApiResponse<LibraryDto>> GetLibraryAsync(string authUserId)
    {
        return await apiClient.GetAsync<LibraryDto>($"{EndpointStrings.GetLibrary}?authUserId={authUserId}");
    }
}

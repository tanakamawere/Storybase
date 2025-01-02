using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class SalesClient
{
    private readonly IApiClient _apiClient;
    public SalesClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    //Get sales by authId
    public async Task<ApiResponse<SalesPageDto>> GetSalesPageDto(string authId)
    {
        return await _apiClient.GetAsync<SalesPageDto>($"{EndpointStrings.GetWriterSales}?authId={authId}");
    }
}

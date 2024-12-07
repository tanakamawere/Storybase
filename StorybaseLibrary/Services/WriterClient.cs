using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Models;

namespace Storybase.Application.Services;

public class WriterClient
{
    private readonly IApiClient _apiClient;

    public WriterClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<WriterDto>> GetWriterByIdAsync(int id)
    {
        return await _apiClient.GetAsync<WriterDto>($"{EndpointStrings.GetWriterById}?id={id}");
    }

    public async Task<ApiResponse<WriterDto>> AddWriterAsync(WriterDto writer)
    {
        return await _apiClient.PostAsync<WriterDto>($"{EndpointStrings.CreateWriter}", writer);
    }

    public async Task<ApiResponse<WriterDto>> DeleteWriterAsync(int id)
    {
        return await _apiClient.DeleteAsync<WriterDto>($"{EndpointStrings.DeleteWriter}?id={id}");
    }

    public async Task<ApiResponse<WriterDto>> UpdateWriterAsync(WriterDto writer)
    {
        return await _apiClient.PutAsync<WriterDto>($"{EndpointStrings.UpdateWriter}", writer);
    }

    public async Task<ApiResponse<IEnumerable<WriterDto>>> SearchWritersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<WriterDto>>($"{EndpointStrings.SearchWriters}?query={search}");
    }

    public async Task<ApiResponse<IEnumerable<LiteraryWork>>> GetWriterLiteraryWorksAsync(int id)
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.GetWriterLiteraryWorks}?id={id}");
    }

    public async Task<ApiResponse<bool>> IsUserNameTakenAsync(string userName)
    {
        return await _apiClient.GetAsync<bool>($"{EndpointStrings.IsUserNameTaken}?userName={userName}");
    }

    public async Task<ApiResponse<bool>> HasWriterProfileAsync(string userId)
    {
        return await _apiClient.GetAsync<bool>($"{EndpointStrings.HasWriterProfile}?userId={userId}");
    }

    public async Task<ApiResponse<IEnumerable<LiteraryWork>>> GetLiteraryWorksByAuthIdAsync(string auth0id)
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.GetWriterLiteraryByAuthId}?auth0id={auth0id}");
    }
}

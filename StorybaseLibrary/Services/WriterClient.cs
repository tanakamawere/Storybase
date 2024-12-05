using Storybase.Application.Interfaces;
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

    public async Task<WriterDto> GetWriterByIdAsync(int id)
    {
        return await _apiClient.GetAsync<WriterDto>($"{EndpointStrings.GetWriterById}?id={id}");
    }

    public async Task<WriterDto> AddWriterAsync(WriterDto Writer)
    {
        return await _apiClient.PostAsync<WriterDto>($"{EndpointStrings.CreateWriter}", Writer);
    }

    //Delete writer
    public async Task<WriterDto> DeleteWriterAsync(int id)
    {
        return await _apiClient.DeleteAsync<WriterDto>($"{EndpointStrings.DeleteWriter}?id={id}");
    }
    //update writer
    public async Task<WriterDto> UpdateWriterAsync(WriterDto Writer)
    {
        return await _apiClient.PutAsync<WriterDto>($"{EndpointStrings.UpdateWriter}", Writer);
    }
    //search writer
    public async Task<IEnumerable<WriterDto>> SearchWritersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<WriterDto>>($"{EndpointStrings.SearchWriters}?query={search}");
    }
    //Get writer literary works
    public async Task<IEnumerable<LiteraryWork>> GetWriterLiteraryWorksAsync(int id)
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.GetWriterLiteraryWorks}?id={id}");
    }
    //Check if username is taken
    public async Task<bool> IsUserNameTakenAsync(string userName)
    {
        return await _apiClient.GetAsync<bool>($"{EndpointStrings.IsUserNameTaken}?userName={userName}");
    }
    //Check if the user already has a writer profile
    public async Task<bool> HasWriterProfileAsync(string userId)
    {
        return await _apiClient.GetAsync<bool>($"{EndpointStrings.HasWriterProfile}?userId={userId}");
    }
}

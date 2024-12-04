using Storybase.Application.Interfaces;
using Storybase.Core;
using Storybase.Core.Models;

namespace Storybase.Application.Services;

public class WriterClient
{
    private readonly IApiClient _apiClient;

    public WriterClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Writer> GetWriterByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Writer>($"{EndpointStrings.GetWriterById}?id={id}");
    }

    public async Task<Writer> AddWriterAsync(Writer Writer)
    {
        return await _apiClient.PostAsync<Writer>($"{EndpointStrings.CreateWriter}", Writer);
    }

    //Delete writer
    public async Task<Writer> DeleteWriterAsync(int id)
    {
        return await _apiClient.DeleteAsync<Writer>($"{EndpointStrings.DeleteWriter}?id={id}");
    }
    //update writer
    public async Task<Writer> UpdateWriterAsync(Writer Writer)
    {
        return await _apiClient.PutAsync<Writer>($"{EndpointStrings.UpdateWriter}", Writer);
    }
    //search writer
    public async Task<IEnumerable<Writer>> SearchWritersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Writer>>($"{EndpointStrings.SearchWriters}?query={search}");
    }
    //Get writer literary works
    public async Task<IEnumerable<LiteraryWork>> GetWriterLiteraryWorksAsync(int id)
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.GetWriterLiteraryWorks}?id={id}");
    }
}

using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class LiteraryWorkClient
{
    private readonly IApiClient _apiClient;

    public LiteraryWorkClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<LiteraryWork> GetLiteraryWorkByIdAsync(int id)
    {
        return await _apiClient.GetAsync<LiteraryWork>($"{EndpointStrings.GetLiteraryWorkById}?id={id}");
    }

    public async Task<LiteraryWork> AddLiteraryWorkAsync(LiteraryWork LiteraryWork)
    {
        return await _apiClient.PostAsync<LiteraryWork>($"{EndpointStrings.CreateLiteraryWork}", LiteraryWork);
    }

    //Delete LiteraryWork
    public async Task<string> DeleteLiteraryWorkAsync(int id)
    {
        return await _apiClient.GetAsync<string>($"{EndpointStrings.DeleteLiteraryWork}?id={id}");
    }
    //update LiteraryWork
    public async Task<LiteraryWork> UpdateLiteraryWorkAsync(LiteraryWork LiteraryWork)
    {
        return await _apiClient.PutAsync<LiteraryWork>($"{EndpointStrings.UpdateLiteraryWork}", LiteraryWork);
    }
    //search LiteraryWork
    public async Task<IEnumerable<LiteraryWork>> SearchLiteraryWorksAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.SearchLiteraryWorks}?query={search}");
    }
    //Get all LiteraryWorks
    public async Task<IEnumerable<LiteraryWork>> GetLiteraryWorksAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>(EndpointStrings.GetAllLiteraryWorks);
    }
    //Unarchive/undelete lw
    public async Task<string> UnarchiveLiteraryWork(int id)
    {
        return await _apiClient.GetAsync<string>($"{EndpointStrings.UnarchiveLiteraryWork}?id={id}");
    }
}

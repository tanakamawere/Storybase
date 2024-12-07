using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;
using Storybase.Core.DTOs;
using Storybase.Application.Models;

namespace Storybase.Application.Services
{
    public class LiteraryWorkClient
    {
        private readonly IApiClient _apiClient;

        public LiteraryWorkClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<LiteraryWork>> GetLiteraryWorkByIdAsync(int id)
        {
            return await _apiClient.GetAsync<LiteraryWork>($"{EndpointStrings.GetLiteraryWorkById}?id={id}");
        }

        public async Task<ApiResponse<string>> AddLiteraryWorkAsync(LiteraryWorkDto literaryWork)
        {
            return await _apiClient.PostAsync<string>($"{EndpointStrings.CreateLiteraryWork}", literaryWork);
        }

        public async Task<ApiResponse<string>> DeleteLiteraryWorkAsync(int id)
        {
            return await _apiClient.DeleteAsync<string>($"{EndpointStrings.DeleteLiteraryWork}?id={id}");
        }

        public async Task<ApiResponse<string>> UpdateLiteraryWorkAsync(LiteraryWorkDto literaryWork)
        {
            return await _apiClient.PutAsync<string>($"{EndpointStrings.UpdateLiteraryWork}", literaryWork);
        }

        public async Task<ApiResponse<IEnumerable<LiteraryWork>>> SearchLiteraryWorksAsync(string search)
        {
            return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>($"{EndpointStrings.SearchLiteraryWorks}?query={search}");
        }

        public async Task<ApiResponse<IEnumerable<LiteraryWork>>> GetLiteraryWorksAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<LiteraryWork>>(EndpointStrings.GetAllLiteraryWorks);
        }

        public async Task<ApiResponse<string>> UnarchiveLiteraryWorkAsync(int id)
        {
            return await _apiClient.GetAsync<string>($"{EndpointStrings.UnarchiveLiteraryWork}?id={id}");
        }
    }
}

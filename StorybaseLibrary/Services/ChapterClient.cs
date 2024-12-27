using Storybase.Core.Models;
using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;

namespace Storybase.Application.Services
{
    public class ChapterClient
    {
        private readonly IApiClient _apiClient;

        public ChapterClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<Chapter>> GetChapterByIdAsync(int id)
        {
            return await _apiClient.GetAsync<Chapter>($"{EndpointStrings.GetChapterById}?id={id}");
        }

        public async Task<ApiResponse<string>> AddChapterAsync(Chapter chapter)
        {
            return await _apiClient.PostAsync<string>($"{EndpointStrings.CreateChapter}", chapter);
        }

        public async Task<ApiResponse<string>> DeleteChapterAsync(int id)
        {
            return await _apiClient.DeleteAsync<string>($"{EndpointStrings.DeleteChapter}?id={id}");
        }

        public async Task<ApiResponse<Chapter>> UpdateChapterAsync(Chapter chapter)
        {
            return await _apiClient.PutAsync<Chapter>($"{EndpointStrings.UpdateChapter}", chapter);
        }

        public async Task<ApiResponse<IEnumerable<Chapter>>> SearchChaptersAsync(string search)
        {
            return await _apiClient.GetAsync<IEnumerable<Chapter>>($"{EndpointStrings.SearchChapters}?query={search}");
        }
    }
}

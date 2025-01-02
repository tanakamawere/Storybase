using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.Models.Payouts;

namespace Storybase.Application.Services;

public class UserPayoutMethodsClient
{
    private readonly IApiClient apiClient;
    public UserPayoutMethodsClient(IApiClient _apiClient)
    {
        apiClient = _apiClient;
    }

    public async Task<ApiResponse<IEnumerable<UserPayoutChoice>>> GetPayoutMethodsAsync(string authId)
    {
        return await apiClient.GetAsync<IEnumerable<UserPayoutChoice>>($"{EndpointStrings.GetUserPayoutMethods}?authId={authId}");
    }

    public async Task<ApiResponse<string>> AddPayoutMethodAsync(UserPayoutChoice userPayoutChoice)
    {
        return await apiClient.PostAsync<string>($"{EndpointStrings.AddUserPayoutMethod}", userPayoutChoice);
    }

    public async Task<ApiResponse<string>> UpdatePayoutMethodAsync(UserPayoutChoice userPayoutChoice)
    {
        return await apiClient.PutAsync<string>($"{EndpointStrings.UpdateUserPayoutMethod}", userPayoutChoice);
    }
}

using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.Models.Payouts;

namespace Storybase.Application.Services;

public class PayoutRequestsClient
{
    private readonly IApiClient _apiClient;
    public PayoutRequestsClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    //Create a new payout
    public async Task<ApiResponse<PayoutRequestResponse>> CreatePayoutRequestAsync(PayoutRequest payoutRequest)
    {
        return await _apiClient.PostAsync<PayoutRequestResponse>(EndpointStrings.CreatePayout, payoutRequest);
    }

    //update a payout
    public async Task<ApiResponse<string>> UpdatePayoutRequestAsync(PayoutRequest payoutRequest)
    {
        return await _apiClient.PutAsync<string>(EndpointStrings.UpdatePayout, payoutRequest);
    }

    //Confirm a payout
    public async Task<ApiResponse<string>> ConfirmPayoutAsync(PayoutConfirmationDto payoutConfirmationDto)
    {
        return await _apiClient.PostAsync<string>(EndpointStrings.ConfirmPayout, payoutConfirmationDto);
    }
}

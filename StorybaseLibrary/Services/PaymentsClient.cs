using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.Models;

namespace Storybase.Application.Services;

public class PaymentsClient
{
    private readonly IApiClient _apiClient;
    public PaymentsClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<Payments>> GetPaymentByTransactionIdAsync(string transactionId)
    {
        return await _apiClient.GetAsync<Payments>($"{EndpointStrings.GetPaymentByTransactionId}?transactionId={transactionId}");
    }
}

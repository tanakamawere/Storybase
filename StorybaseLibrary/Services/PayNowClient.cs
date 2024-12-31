using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class PayNowClient
{
    private readonly IApiClient apiClient;
    public PayNowClient(IApiClient api)
    {
        apiClient = api;
    }

    public async Task<ApiResponse<PaymentInitResponseDto>> InitiatePaymentAsync(PaymentRequestDto paymentRequest)
    {
        return await apiClient.PostAsync<PaymentInitResponseDto>(EndpointStrings.InitializePayment, paymentRequest);
    }

    public async Task<ApiResponse<PaymentCheckResponseDto>> CheckPaymentStatusAsync(string pollUrl)
    {
        return await apiClient.GetAsync<PaymentCheckResponseDto>($"{EndpointStrings.CheckPaymentStatus}?pollUrl={pollUrl}");
    }
    //Mobile transaction init
    public async Task<ApiResponse<PaymentInitResponseDto>> InitializeMobilePaymentAsync(PaymentRequestDto paymentRequest)
    {
        return await apiClient.PostAsync<PaymentInitResponseDto>(EndpointStrings.InitializeMobilePayment, paymentRequest);
    }
}

using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;
using Storybase.Application.Models;
using Storybase.Core.DTOs;

namespace Storybase.Application.Services;

public class PurchaseClient
{
    private readonly IApiClient _apiClient;

    public PurchaseClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<Purchase>> GetPurchaseByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Purchase>($"{EndpointStrings.GetPurchaseById}?id={id}");
    }

    public async Task<ApiResponse<string>> AddPurchaseAsync(PurchasesDto purchase)
    {
        return await _apiClient.PostAsync<string>($"{EndpointStrings.CreatePurchase}", purchase);
    }

    public async Task<ApiResponse<string>> DeletePurchaseAsync(int id)
    {
        return await _apiClient.DeleteAsync<string>($"{EndpointStrings.DeletePurchase}?id={id}");
    }

    public async Task<ApiResponse<Purchase>> UpdatePurchaseAsync(Purchase purchase)
    {
        return await _apiClient.PutAsync<Purchase>($"{EndpointStrings.UpdatePurchase}", purchase);
    }

    public async Task<ApiResponse<IEnumerable<Purchase>>> SearchPurchasesAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Purchase>>($"{EndpointStrings.SearchPurchases}?query={search}");
    }

    public async Task<ApiResponse<IEnumerable<Purchase>>> GetPurchasesAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<Purchase>>(EndpointStrings.GetAllPurchases);
    }
    // Get all purchases by user
    public async Task<ApiResponse<IEnumerable<Purchase>>> GetPurchasesByUserAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<Purchase>>(EndpointStrings.GetPurchasesByUser);
    }
    // Get purchase by authuserid and litwork
    public async Task<ApiResponse<PurchaseStatusDto>> GetPurchaseByAuthUserIdAndLiteraryWorkIdAsync(PurchaseLitWorkDto purchaseLitWorkDto)
    {
        return await _apiClient.PostAsync<PurchaseStatusDto>($"{EndpointStrings.GetPurchaseByAuthUserIdAndLiteraryWorkId}", purchaseLitWorkDto);
    }
}

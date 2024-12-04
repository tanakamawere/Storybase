using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class PurchaseClient
{
    private readonly IApiClient _apiClient;

    public PurchaseClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Purchase> GetPurchaseByIdAsync(int id)
    {
        return await _apiClient.GetAsync<Purchase>($"{EndpointStrings.GetPurchaseById}?id={id}");
    }

    public async Task<Purchase> AddPurchaseAsync(Purchase Purchase)
    {
        return await _apiClient.PostAsync<Purchase>($"{EndpointStrings.CreatePurchase}", Purchase);
    }

    //Delete Purchase
    public async Task<Purchase> DeletePurchaseAsync(int id)
    {
        return await _apiClient.DeleteAsync<Purchase>($"{EndpointStrings.DeletePurchase}?id={id}");
    }
    //update Purchase
    public async Task<Purchase> UpdatePurchaseAsync(Purchase Purchase)
    {
        return await _apiClient.PutAsync<Purchase>($"{EndpointStrings.UpdatePurchase}", Purchase);
    }
    //search Purchase
    public async Task<IEnumerable<Purchase>> SearchPurchasesAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<Purchase>>($"{EndpointStrings.SearchPurchases}?query={search}");
    }
    //Get all Purchases
    public async Task<IEnumerable<Purchase>> GetPurchasesAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<Purchase>>(EndpointStrings.GetAllPurchases);
    }
}

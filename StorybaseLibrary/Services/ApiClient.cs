using Storybase.Application.Interfaces;
using System.Net.Http.Json;

namespace Storybase.Application.Services;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode(); // Throws an exception if not 2xx
        var data = await response.Content.ReadFromJsonAsync<T>();
        return data;
    }

    public async Task<T> PostAsync<T>(string url, object data)
    {
        var response = await _httpClient.PostAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<T>();
        return result;
    }

    public async Task<T> PutAsync<T>(string url, object data)
    {
        var response = await _httpClient.PutAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<T>();
        return result;
    }

    public async Task<T> DeleteAsync<T>(string uri)
    {
        var response = await _httpClient.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<T>();
        return result;
    }
}

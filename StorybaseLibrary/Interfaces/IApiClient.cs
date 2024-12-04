namespace Storybase.Application.Interfaces;

public interface IApiClient
{
    Task<T> GetAsync<T>(string uri);
    Task<T> PostAsync<T>(string uri, object data);
    Task<T> PutAsync<T>(string uri, object data);
    Task<T> DeleteAsync<T>(string uri);
}

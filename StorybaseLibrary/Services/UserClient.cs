using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;
using Storybase.Application.Models;

namespace Storybase.Application.Services;

public class UserClient
{
    private readonly IApiClient _apiClient;

    public UserClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponse<User>> GetUserByIdAsync(int id)
    {
        return await _apiClient.GetAsync<User>($"{EndpointStrings.GetUserById}?id={id}");
    }

    public async Task<ApiResponse<User>> AddUserAsync(User user)
    {
        return await _apiClient.PostAsync<User>($"{EndpointStrings.CreateUser}", user);
    }

    public async Task<ApiResponse<User>> DeleteUserAsync(int id)
    {
        return await _apiClient.DeleteAsync<User>($"{EndpointStrings.DeleteUser}?id={id}");
    }

    public async Task<ApiResponse<User>> UpdateUserAsync(User user)
    {
        return await _apiClient.PutAsync<User>($"{EndpointStrings.UpdateUser}", user);
    }

    public async Task<ApiResponse<IEnumerable<User>>> SearchUsersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<User>>($"{EndpointStrings.SearchUsers}?query={search}");
    }

    public async Task<ApiResponse<IEnumerable<User>>> GetUsersAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<User>>(EndpointStrings.GetAllUsers);
    }
}

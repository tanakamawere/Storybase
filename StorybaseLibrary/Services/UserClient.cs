using Storybase.Core.Models;
using Storybase.Core;
using Storybase.Application.Interfaces;

namespace Storybase.Application.Services;

public class UserClient
{
    private readonly IApiClient _apiClient;

    public UserClient(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _apiClient.GetAsync<User>($"{EndpointStrings.GetUserById}?id={id}");
    }

    public async Task<User> AddUserAsync(User User)
    {
        return await _apiClient.PostAsync<User>($"{EndpointStrings.CreateUser}", User);
    }

    //Delete User
    public async Task<User> DeleteUserAsync(int id)
    {
        return await _apiClient.DeleteAsync<User>($"{EndpointStrings.DeleteUser}?id={id}");
    }
    //update User
    public async Task<User> UpdateUserAsync(User User)
    {
        return await _apiClient.PutAsync<User>($"{EndpointStrings.UpdateUser}", User);
    }
    //search User
    public async Task<IEnumerable<User>> SearchUsersAsync(string search)
    {
        return await _apiClient.GetAsync<IEnumerable<User>>($"{EndpointStrings.SearchUsers}?query={search}");
    }
    //Get all users
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<User>>(EndpointStrings.GetAllUsers);
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using Storybase.Core.DTOs;
using Storybase.Core.Models;
using System.Net.Http;
using System.Security.Claims;

namespace Storybase.Application.Services;

public class UserService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private string _auth0UserId;
    private AuthenticationState? authState;
    private ClaimsPrincipal? claimsPrincipal;

    public UserService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string> GetAuth0UserIdAsync()
    {
        // Return cached value if already retrieved
        if (!string.IsNullOrEmpty(_auth0UserId))
            return _auth0UserId;

        // Get the authentication state
        authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        claimsPrincipal = authState.User;

        // Extract the Auth0UserId
        _auth0UserId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "";

        return _auth0UserId;
    }

    // Get the user object with authUserId, email and name
    public async Task<UserDto> GetUserAsync()
    {
        try
        {
            // Get the authentication state
            authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            claimsPrincipal = authState.User;

            //iterate over the claims and print to console
            foreach (var item in claimsPrincipal.Claims)
            {
                Console.WriteLine($"{item.Type} - {item.Value}");
            }

            // Create a new user
            var user = new UserDto
            {
                Name = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "nickname")?.Value,
                Email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                ImageUrl = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                Auth0UserId = await GetAuth0UserIdAsync()
            };
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Error getting user", ex);
        }
    }

    public async Task<bool> IsLoggedIn()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (authState.User.Identity.IsAuthenticated)
        {
            return true;
        }
        return false;
    }
    private async Task<User> GetUserObjectAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        claimsPrincipal = authState.User;

        // Create a new user
        return new User
        {
            Name = claimsPrincipal.FindFirst("nickname")?.Value,
            Email = claimsPrincipal.FindFirst("name")?.Value,
            Auth0UserId = claimsPrincipal.FindFirst("sub")?.Value,
            ImageUrl = claimsPrincipal.FindFirst("picture")?.Value
        };
    }
}


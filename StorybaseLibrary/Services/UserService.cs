using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Storybase.Application.Services;

public class UserService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private string _auth0UserId;

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
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        // Extract the Auth0UserId
        _auth0UserId = user.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "";

        return _auth0UserId;
    }
}


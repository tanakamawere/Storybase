using Storybase.Core.DTOs;
using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    // Get user by Auth0UserId
    Task<User> GetByAuth0UserIdAsync(string auth0UserId);
    // Check if email is taken
    Task<bool> IsEmailTakenAsync(string email);
    Task<string> GetUserId(string auth0UserId);
    Task<bool> CheckIfUserExistsAsync(UserDto user);
}

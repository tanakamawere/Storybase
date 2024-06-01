using StorybaseLibrary.Models;
using System.Security.Claims;

namespace StorybaseApi.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(string userId, string username, string phoneNumber, UserRole userRole, string jwtSecret, int expiryMinutes);
    }
}

using Microsoft.AspNetCore.Identity;
using StorybaseApi.Interfaces;

namespace StorybaseApi.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

            if (verified)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

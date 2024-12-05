using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByAuth0UserIdAsync(string auth0UserId)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == auth0UserId);
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }
}

using Storybase.Core.DTOs;
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

    public async Task<bool> CheckIfUserExistsAsync(UserDto userDto)
    {
        //Get the user and check if they exist, if they don't, add them to the db. If they do, return the true
        var userExists = await _context.Users.AnyAsync(x => x.Auth0UserId == userDto.Auth0UserId);

        if (!userExists)
        {
            //Create user object from userDto
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Auth0UserId = userDto.Auth0UserId,
                ImageUrl = userDto.ImageUrl
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        return userExists;
    }

    public async Task<User> GetByAuth0UserIdAsync(string auth0UserId)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == auth0UserId);
    }

    public async Task<string> GetUserId(string auth0UserId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == auth0UserId);
        return user.Id.ToString();
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }
}

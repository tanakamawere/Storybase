using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Repositories;
public class LibraryRepository : ILibraryRepository
{
    private readonly AppDbContext context;

    public LibraryRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<LibraryDto> LibraryDto(string authUserId)
    {
        //Get the current user's bookmarks and purchases, if any, and add them to the LibraryDto
        var bookmarks = await context.Bookmarks.Where(b => b.User.Auth0UserId == authUserId)
            .AsNoTracking()
            .Include(p => p.LiteraryWork)
                .ThenInclude(lw => lw.Writer)
            .ToListAsync();
        var purchases = await context.Purchases
            .AsNoTracking()
            .Include(p => p.LiteraryWork)
                .ThenInclude(lw => lw.Writer)
            .Where(p => p.User.Auth0UserId == authUserId)
            .ToListAsync();
        return new LibraryDto
        {
            Bookmarks = bookmarks,
            Purchases = purchases
        };
    }
}

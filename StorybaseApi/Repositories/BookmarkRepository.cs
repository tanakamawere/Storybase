using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class BookmarkRepository : GenericRepository<Bookmark>,IBookmarkRepository
{
    private readonly AppDbContext context;
    public BookmarkRepository(AppDbContext _context) : base(_context)
    {
        context = _context;
    }
    public async Task AddBookmarkDto(BookmarkDto bookmarkDto)
    {
        Bookmark bookmark = new()
        {
            User = await context.Users.Where(c => c.Auth0UserId == bookmarkDto.AuthUserId).FirstOrDefaultAsync(),
            DateAdded = DateTime.Now,
            LiteraryWork = await context.LiteraryWorks.FindAsync(bookmarkDto.LiteraryWorkId),
        };

        await context.Bookmarks.AddAsync(bookmark);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Bookmark>> GetByUserIdAsync(int userId)
    {
        return await context.Bookmarks
                .Where(b  => b.UserId == userId).ToListAsync();
    }
}

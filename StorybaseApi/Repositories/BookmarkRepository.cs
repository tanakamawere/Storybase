using Storybase.Core.DTOs;
using Storybase.Core.Enums;
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
    public async Task<BookmarkStatus> AddBookmarkDto(BookmarkDto bookmarkDto)
    {
        //check if user has already bookmarked the work
        var bookmark = await context.Bookmarks
            .Where(b => b.User.Auth0UserId == bookmarkDto.AuthUserId && b.LiteraryWorkId == bookmarkDto.LiteraryWorkId)
            .FirstOrDefaultAsync();
        if (bookmark != null)
        {
            return BookmarkStatus.AlreadyBookmarked;
        }
        else
        {
            Bookmark newBookmark = new Bookmark
            {
                User = await context.Users.Where(c => c.Auth0UserId == bookmarkDto.AuthUserId).FirstOrDefaultAsync(),
                DateAdded = DateTime.Now,
                LiteraryWork = await context.LiteraryWorks.FindAsync(bookmarkDto.LiteraryWorkId),
            };
            await context.Bookmarks.AddAsync(newBookmark);
            await context.SaveChangesAsync();
            return BookmarkStatus.Bookmarked;
        }
    }

    public async Task<IEnumerable<Bookmark>> GetByUserIdAsync(int userId)
    {
        return await context.Bookmarks
                .Where(b  => b.UserId == userId).ToListAsync();
    }
}

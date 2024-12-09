using Storybase.Core.DTOs;
using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IBookmarkRepository : IRepository<Bookmark>
{
    Task<IEnumerable<Bookmark>> GetByUserIdAsync(int userId);

    Task AddBookmarkDto(BookmarkDto bookmarkDto);
}


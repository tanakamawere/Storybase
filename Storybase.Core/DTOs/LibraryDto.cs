using Storybase.Core.Models;

namespace Storybase.Core.DTOs;

public class LibraryDto
{
    public IEnumerable<Bookmark>? Bookmarks { get; set; }
    public IEnumerable<Purchase>? Purchases { get; set; }
}

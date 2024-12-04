namespace Storybase.Core.Models;

public class Bookmark
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int LiteraryWorkId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}


namespace Storybase.Core.Models;

public class ReadingProgress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int LiteraryWorkId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }
    public int? ChapterNumber { get; set; } // For books
    public double Percentage { get; set; } // For prose, poems, or essays
    public DateTime LastAccessed { get; set; } = DateTime.UtcNow;
}


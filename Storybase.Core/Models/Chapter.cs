using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class Chapter
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }

    public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    public int ChapterNumber { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    // Pricing
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ChapterPrice { get; set; }
}

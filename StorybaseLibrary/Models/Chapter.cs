using System.ComponentModel.DataAnnotations.Schema;

namespace StorybaseLibrary.Models;

public class Chapter
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    public int ChapterNumber { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    //This is price and should be correct to 2dp
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public Book Book { get; set; }
}

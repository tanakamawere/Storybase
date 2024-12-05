using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class Chapter
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }

    public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    //Chapter number should be unique   
    public int ChapterNumber { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    //Soft delete
    public bool IsDeleted { get; set; } = false;
}

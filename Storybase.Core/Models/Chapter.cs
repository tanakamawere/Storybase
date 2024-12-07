using System.ComponentModel.DataAnnotations;

namespace Storybase.Core.Models;

public class Chapter
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public LiteraryWork LiteraryWork { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    public int ChapterNumber { get; set; } = 1;

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; } = "";

    public bool IsDeleted { get; set; } = false;
}

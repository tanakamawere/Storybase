using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class LiteraryWork
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? LastModified { get; set; }

    // Type: Book, Prose, Poem
    public LiteraryWorkType Type { get; set; }

    // Free or paid
    public bool IsFree { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, 1, ErrorMessage = "FreePreviewPercentage must be between 0 and 1.")]
    public double FreePreviewPercentage { get; set; } // For essays/poems (e.g., 0.25 = 25% free)

    // Relationships
    public int WriterId { get; set; }
    public Writer Writer { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public ICollection<Chapter> Chapters { get; set; }

    // For books
    public bool ProgressiveWriting { get; set; } // True if book is being written progressively
    public bool Completed { get; set; } // True if book is fully written

    //Soft delete
    public bool IsDeleted { get; set; } = false;
}
public enum LiteraryWorkType
{
    Book,
    Prose,
    Poem,
    Essay
}

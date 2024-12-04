using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class LiteraryWork
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string CoverImageUrl { get; set; }

    // Type: Book, Prose, Poem
    public LiteraryWorkType Type { get; set; }

    // Free or paid
    public bool IsFree { get; set; }

    // Pricing
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; } // For completed books, essays, and poems
    public double? FreePreviewPercentage { get; set; } // For essays/poems (e.g., 0.25 = 25% free)

    // Relationships
    public int WriterId { get; set; }
    public Writer Writer { get; set; }
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    // For books
    public bool ProgressiveWriting { get; set; } // True if book is being written progressively
    public bool Completed { get; set; } // True if book is fully written
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? FullBookPrice { get; set; }

    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}
public enum LiteraryWorkType
{
    Book,
    Prose,
    Poem,
    Essay
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class Pricing
{
    public int Id { get; set; }

    // Type of pricing: Book, Chapter, Poem, etc.
    public PricingType PricingType { get; set; }

    // Price value
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    // Relationships
    public int? LiteraryWorkId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }

    public int? ChapterId { get; set; }
    public Chapter Chapter { get; set; }

    // Metadata
    public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
}

public enum PricingType
{
    FullBook,
    Chapter,
    Other
}

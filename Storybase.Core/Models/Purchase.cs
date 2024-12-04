namespace Storybase.Core.Models;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public PurchaseType PurchaseType { get; set; }

    // For Chapter Purchases
    public int? ChapterId { get; set; }
    public Chapter Chapter { get; set; }

    // For LiteraryWork Purchases
    public int? LiteraryWorkId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }

    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
}
public enum PurchaseType
{
    Chapter,
    LiteraryWork
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    // For LiteraryWork Purchases
    public int? LiteraryWorkId { get; set; }
    public LiteraryWork LiteraryWork { get; set; }
    //Save the amount of the purchase here because the price might be changed where the literary work is
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
}
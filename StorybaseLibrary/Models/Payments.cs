using System.ComponentModel.DataAnnotations.Schema;

namespace StorybaseLibrary.Models;

public class Payments
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? BookId { get; set; }
    public int? ChapterId { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    //This is amount and should be correct to 2dp
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public StorybaseUser User { get; set; }
    public Book Book { get; set; }
    public Chapter Chapter { get; set; }
}

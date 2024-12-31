using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Storybase.Core.Models;

public class Payments
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }
    public string PollUrl { get; set; }
    public string Reference { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public enum PaymentStatus
{
    Pending,
    Paid,
    Failed,
    NotPaid
}

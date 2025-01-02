using System.ComponentModel.DataAnnotations.Schema;

namespace Storybase.Core.Models.Payouts;

public class PayoutRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PayoutMethodId { get; set; }
    public UserPayoutChoice UserPayoutMethod { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal AmountRequested { get; set; }
    public DateTime RequestDate { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public DateTime LastModified { get; set; }
    public PayoutStatus PayoutStatus { get; set; }
}

public class PayoutRequestDto
{
    public string UserAuthId { get; set; }
    public int PayoutMethodId { get; set; }
    public decimal AmountRequested { get; set; }
    public DateTime RequestDate { get; set; }
    public PayoutStatus PayoutStatus { get; set; } = PayoutStatus.Pending;
}

public class PayoutConfirmationDto
{
    public int PayoutRequestId { get; set; }
    public bool IsConfirmed { get; set; }
}

public class PayoutRequestResponse
{
    public decimal AmountRequested { get; set; }

    //This number is a percentage
    public decimal CutFee { get; set; }
    public decimal NetAmount { get; set; }
    public DateTime RequestDate { get; set; }
    public PayoutMethod PayoutMethod { get; set; }
    public PayoutStatus PayoutStatus { get; set; }
    public string Message { get; set; }
}

public enum PayoutStatus
{
    Pending,
    Paid,
    Failed,
    Denied,
    Cancelled
}

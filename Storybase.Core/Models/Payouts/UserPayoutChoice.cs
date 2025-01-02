namespace Storybase.Core.Models.Payouts;

public class UserPayoutChoice
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public PayoutMethod PayoutMethod { get; set; } // "Bank", "EcoCash", "Innbucks", etc.

    //If payout method is Bank, these fields are required
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; } // Required for Bank
    public string Branch { get; set; } // Required for Bank
    public string MobileNumber { get; set; } // Required for Mobile Banking
    public bool IsDefault { get; set; }
}

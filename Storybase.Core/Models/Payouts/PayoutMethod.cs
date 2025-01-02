namespace Storybase.Core.Models.Payouts;

public class PayoutMethod
{
    public int Id { get; set; }

    /// <summary>
    /// The name of the payout method, e.g., Innbucks, Ecocash.
    /// </summary>
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public PayoutMethodType PayoutMethodType { get; set; } = PayoutMethodType.Mobile;

    /// <summary>
    /// A description of the payout method, detailing how it works or any restrictions.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether the payout method is currently active or available.
    /// </summary>
    public bool IsActive { get; set; }
}

public enum PayoutMethodType
{
    Bank,
    Mobile
}

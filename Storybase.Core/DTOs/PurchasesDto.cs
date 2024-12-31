namespace Storybase.Core.DTOs;

public class PurchasesDto
{
    //Used to log the purchase after payment
    public string UserId { get; set; } = "";
    public string AuthUserId { get; set; }

    // For LiteraryWork Purchases
    public int? LiteraryWorkId { get; set; }

    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
}

public class PurchaseStatusDto
{
    public int PurchaseId { get; set; }
    public bool IsPurchased { get; set; }
    public DateTime PurchaseDate { get; set; }
}

public class PurchaseLitWorkDto
{
    public string AuthUserId { get; set; }
    public int LiteraryWorkId { get; set; }
}

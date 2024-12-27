using System.IO.Pipes;

namespace Storybase.Core.DTOs;
public class PaymentRequestDto
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string UserEmail { get; set; } = "tanaka@tanakamawere.co.zw";
    public string? PhoneNumber { get; set; } = "";
    public string? Name { get; set; } = "";
    public MobileMoneyGateways? MobileGateway { get; set; } = MobileMoneyGateways.Ecocash;
}

public class PaymentInitResponseDto
{
    public string RedirectLink { get; set; }
    public string PollUrl { get; set; }
    public bool IsSuccess { get; set; }
}

public class PaymentCheckResponseDto
{
    public string Errors { get; set; }
    public bool IsSuccess { get; set; }
    public decimal Amount { get; set; }
    public string PollUrl { get; set; }
    public string Reference { get; set; }   
}

public class PaymentNotificationDto
{
    public string PollUrl { get; set; }
    public string TransactionId { get; set; }
}
public enum MobileMoneyGateways
{
    Ecocash,
    Innbucks,
    OneMoney
}

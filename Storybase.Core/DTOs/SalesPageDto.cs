using Storybase.Core.Models;
using Storybase.Core.Models.Payouts;

namespace Storybase.Core.DTOs;

public class SalesPageDto
{
    public IEnumerable<Purchase> Purchases { get; set; }
    public IEnumerable<PayoutRequest> PayoutRequests { get; set; }
    public decimal? AvailableBalance { get; set; } = 0;
}

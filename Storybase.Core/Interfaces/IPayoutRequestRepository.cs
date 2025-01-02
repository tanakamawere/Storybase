using Storybase.Core.Models.Payouts;

namespace Storybase.Core.Interfaces;

public interface IPayoutRequestRepository : IRepository<PayoutRequest>
{
    Task<PayoutRequestResponse> AddPayoutRequestDto(PayoutRequestDto payoutRequestDto);
    Task<string> ConfirmPayout(PayoutConfirmationDto payoutConfirmationDto);
}

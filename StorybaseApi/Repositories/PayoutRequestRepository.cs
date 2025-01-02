using Microsoft.EntityFrameworkCore;
using Storybase.Core.Interfaces;
using Storybase.Core.Models.Payouts;

namespace StorybaseApi.Repositories;

public class PayoutRequestRepository : GenericRepository<PayoutRequest>, IPayoutRequestRepository
{
    private readonly AppDbContext context;
    private readonly IConfiguration configuration;
    public PayoutRequestRepository(AppDbContext context, IConfiguration configuration) : base(context)
    {
        this.context = context;
        this.configuration = configuration;
    }

    public async Task<PayoutRequestResponse> AddPayoutRequestDto(PayoutRequestDto payoutRequestDto)
    {
        PayoutRequestResponse response = new PayoutRequestResponse();

        var user = await context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == payoutRequestDto.UserAuthId);

        //if the user already has a pending payout request, return failed payout request message
        var pendingPayoutRequest = await context.PayoutRequests.
                                    Where(h => h.UserId == user.Id).
                                    Where(n => n.PayoutStatus == PayoutStatus.Pending).
                                    FirstOrDefaultAsync();
        if (pendingPayoutRequest != null)
        {
            response.PayoutStatus = PayoutStatus.Denied;
            response.Message = "Payout already requested";
        }
        else
        {
            var payoutRequest = new PayoutRequest
            {
                User = user,
                UserPayoutMethod = await context.UserPayoutChoices.
                                    Where(h => h.UserId == user.Id).
                                    Where(n => n.IsDefault == true).
                                    FirstOrDefaultAsync(),
                AmountRequested = payoutRequestDto.AmountRequested,
                RequestDate = payoutRequestDto.RequestDate,
                PayoutStatus = PayoutStatus.Pending
            };
            await AddAsync(payoutRequest);

            //Return the logged payout request
            response.AmountRequested = payoutRequest.AmountRequested;
            response.RequestDate = payoutRequest.RequestDate;
            response.PayoutMethod = payoutRequest.UserPayoutMethod.PayoutMethod;
            response.PayoutStatus = PayoutStatus.Pending;
            response.Message = "Payout requested successfully";
            //Get the cut fee from the configuration

            var cutFee = Convert.ToDecimal(configuration["PayoutCutFee"]);
            response.CutFee = cutFee;
            response.NetAmount = payoutRequestDto.AmountRequested - (payoutRequestDto.AmountRequested * cutFee);
        }

        return response;
    }

    public async Task<string> ConfirmPayout(PayoutConfirmationDto payoutConfirmationDto)
    {
        var payoutRequest = await context.PayoutRequests.FirstOrDefaultAsync(x => x.Id == payoutConfirmationDto.PayoutRequestId);
        if (payoutRequest == null)
        {
            return "Payout request not found";
        }
        if (payoutConfirmationDto.IsConfirmed)
        {
            payoutRequest.IsConfirmed = true;
            payoutRequest.PayoutStatus = PayoutStatus.Paid;
            await UpdateAsync(payoutRequest);
            return "Payout confirmed successfully";
        }
        else
        {
            payoutRequest.PayoutStatus = PayoutStatus.Cancelled;
            await UpdateAsync(payoutRequest);
            return "Payout cancelled";
        }
    }
}

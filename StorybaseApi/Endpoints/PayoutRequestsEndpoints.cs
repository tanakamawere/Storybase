using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models.Payouts;

namespace StorybaseApi.Endpoints;

public static class PayoutRequestsEndpoints
{
    public static IEndpointRouteBuilder MapPayoutsEndpoints(this IEndpointRouteBuilder app)
    {
        //Get payout by id
        app.MapGet(EndpointStrings.GetPayoutById, async Task<Results<Ok<PayoutRequest>, BadRequest>> (IPayoutRequestRepository repository, int id) =>
        {
            var payout = await repository.GetByIdAsync(id);
            if (payout == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(payout);
        });

        //Create a new payout
        app.MapPost(EndpointStrings.CreatePayout, async Task<Results<Ok<PayoutRequestResponse>, BadRequest<string>>> (IPayoutRequestRepository repository, PayoutRequestDto createPayout) =>
        {
            var response = await repository.AddPayoutRequestDto(createPayout);
            return TypedResults.Ok(response);
        });

        //update a payout
        app.MapPut(EndpointStrings.UpdatePayout, async Task<Results<Ok<string>, BadRequest>> (IPayoutRequestRepository repository, PayoutRequest updatePayout) =>
        {
            await repository.UpdateAsync(updatePayout);
            return TypedResults.Ok("Payout updated successfully");
        });

        //Delete a payout
        app.MapDelete(EndpointStrings.DeletePayout, async Task<Results<Ok<string>, BadRequest>> (IPayoutRequestRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Payout deleted successfully");
        });

        //Confirm payout by user
        app.MapPost(EndpointStrings.ConfirmPayout, async Task<Results<Ok, BadRequest>> (IPayoutRequestRepository repository, PayoutConfirmationDto payoutConfirmationDto) =>
        {
            await repository.ConfirmPayout(payoutConfirmationDto);
            return TypedResults.Ok();
        });

        return app;
    }
}

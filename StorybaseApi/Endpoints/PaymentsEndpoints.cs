using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class PaymentsEndpoints
{
    public static IEndpointRouteBuilder MapPaymentsEndpoints(this IEndpointRouteBuilder app)
    {
        //Get payment by transaction id
        app.MapGet(EndpointStrings.GetPaymentByTransactionId, async Task<Results<Ok<Payments>, BadRequest>> (IPaymentsRepository payments, string transactionId) =>
        {
            var payment = await payments.GetPaymentByTransactionId(Guid.Parse(transactionId));
            return TypedResults.Ok(payment);
        });

        return app;
    }
}

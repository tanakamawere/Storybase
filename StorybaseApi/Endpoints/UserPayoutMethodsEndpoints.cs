using Storybase.Core;
using Storybase.Core.Interfaces;
using Storybase.Core.Models.Payouts;

namespace StorybaseApi.Endpoints;

public static class UserPayoutMethodsEndpoints
{
    public static IEndpointRouteBuilder MapUserPayoutMethodsEndpoints(this IEndpointRouteBuilder app)
    {
        // Get user payout methods
        app.MapGet(EndpointStrings.GetUserPayoutMethods, async Task<Results<Ok<IEnumerable<UserPayoutChoice>>, BadRequest>> (IUserPayoutMethodsRepository userPayoutMethodsRepository, string authId) =>
        {
            var payoutMethods = await userPayoutMethodsRepository.GetPayoutMethodsAsync(authId);
            return TypedResults.Ok(payoutMethods);
        });

        //Add user payout method
        app.MapPost(EndpointStrings.AddUserPayoutMethod, async Task<Results<Ok<UserPayoutChoice>, BadRequest>> (IUserPayoutMethodsRepository userPayoutMethodsRepository, UserPayoutChoice userPayoutChoice) =>
        {
            await userPayoutMethodsRepository.AddAsync(userPayoutChoice);
            return TypedResults.Ok(userPayoutChoice);
        });

        //Update user payout method
        app.MapPut(EndpointStrings.UpdateUserPayoutMethod, async Task<Results<Ok<UserPayoutChoice>, BadRequest>> (IUserPayoutMethodsRepository userPayoutMethodsRepository, UserPayoutChoice userPayoutChoice) =>
        {
            await userPayoutMethodsRepository.UpdateAsync(userPayoutChoice);
            return TypedResults.Ok(userPayoutChoice);
        });


        return app;
    }
}

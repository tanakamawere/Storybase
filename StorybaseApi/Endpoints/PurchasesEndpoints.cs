using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Endpoints;

public static class PurchaseEndpoints
{
    public static IEndpointRouteBuilder MapPurchaseEndpoints(this IEndpointRouteBuilder app)
    {
        //Get Purchase by id
        app.MapGet(EndpointStrings.GetPurchaseById, async Task<Results<Ok<Purchase>, BadRequest>> (IPurchaseRepository repository, int id) =>
        {
            var Purchase = await repository.GetByIdAsync(id);
            if (Purchase == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(Purchase);
        });

        //Create a new Purchase
        app.MapPost(EndpointStrings.CreatePurchase, async Task<Results<Ok<string>, BadRequest>> (IPurchaseRepository repository, PurchasesDto createPurchase) =>
        {
            await repository.AddPurchaseDtoAsync(createPurchase);
            return TypedResults.Ok("Purchase created successfully");
        });
        //Update a Purchase
        app.MapPut(EndpointStrings.UpdatePurchase, async Task<Results<Ok<string>, BadRequest>> (IPurchaseRepository repository, Purchase updatePurchase) =>
        {
            await repository.UpdateAsync(updatePurchase);
            return TypedResults.Ok("Purchase updated successfully");
        });
        //Delete
        app.MapDelete(EndpointStrings.DeletePurchase, async Task<Results<Ok<string>, BadRequest>> (IPurchaseRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return TypedResults.Ok("Purchase deleted successfully");
        });
        //Search
        app.MapGet(EndpointStrings.SearchPurchases, async Task<Results<Ok<IEnumerable<Purchase>>, BadRequest>> (IPurchaseRepository repository, string query) =>
        {
            var Purchases = await repository.SearchAsync(query);
            return TypedResults.Ok(Purchases);
        });
        //GetAll Purchases
        app.MapGet(EndpointStrings.GetAllPurchases, async Task<Results<Ok<IEnumerable<Purchase>>, BadRequest>>(IPurchaseRepository repository) =>
        {
            var purchases = await repository.GetAllAsync();
            return TypedResults.Ok(purchases);
        });
        //Get all Purchases by user
        app.MapGet(EndpointStrings.GetPurchasesByUser, async Task<Results<Ok<IEnumerable<Purchase>>, BadRequest>> (IPurchaseRepository repository) =>
        {
            var purchases = await repository.GetPurchasesByUser();
            return TypedResults.Ok(purchases);
        });

        //Get Purchase by AuthUserId and LiteraryWorkId
        app.MapPost(EndpointStrings.GetPurchaseByAuthUserIdAndLiteraryWorkId, async Task<Results<Ok<PurchaseStatusDto>, BadRequest>> (IPurchaseRepository repository, PurchaseLitWorkDto purchaseLitWorkDto) =>
        {
            var purchaseStatus = await repository.GetIfPurchaseByAuthUserIdAndLiteraryWorkIdAsync(purchaseLitWorkDto);
            return TypedResults.Ok(purchaseStatus);
        });

        return app;
    }
}

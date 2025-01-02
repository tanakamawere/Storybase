using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Endpoints;

public static class SalesEndpoints
{
    public static IEndpointRouteBuilder MapSalesEndpoints(this IEndpointRouteBuilder app)
    {
        //Get writer's sales
        app.MapGet(EndpointStrings.GetWriterSales, async Task<Results<Ok<SalesPageDto>, BadRequest>> (ISalesRepository salesRepository, string authId) =>
        {
            var salesPageDto = await salesRepository.GetSalesPageDto(authId);
            return TypedResults.Ok(salesPageDto);
        });

        return app;
    }
}

using Storybase.Core;
using Storybase.Core.DTOs;
using StorybaseApi.Services;

namespace StorybaseApi.Endpoints;

public static class PayNowEndpoints
{
    public static IEndpointRouteBuilder MapPaynowEndpoints(this IEndpointRouteBuilder app)
    {
        //Initialize payment
        app.MapPost(EndpointStrings.InitializePayment, async Task<Results<Ok<PaymentInitResponseDto>, BadRequest>> (PayNowService payNowService, PaymentRequestDto paymentRequestDto) =>
        {
            var link = await payNowService.InitializePayment(paymentRequestDto);
            return TypedResults.Ok(link);
        });
        //Initialise mobile payment
        app.MapPost(EndpointStrings.InitializeMobilePayment, async Task<Results<Ok<PaymentInitResponseDto>, BadRequest>> (PayNowService payNowService, PaymentRequestDto paymentRequestDto) =>
        {
            var link = await payNowService.InitializeMobilePayment(paymentRequestDto);
            return TypedResults.Ok(link);
        });

        //Check payment status
        app.MapGet(EndpointStrings.CheckPaymentStatus, async Task<Results<Ok<PaymentCheckResponseDto>, BadRequest>> (PayNowService payNowService, string pollUrl) =>
        {
            var response = await payNowService.CheckPaymentStatus(pollUrl);
            return TypedResults.Ok(response);
        });

        return app;
    }
}
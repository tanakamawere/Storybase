using Storybase.Core;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;
using StorybaseApi.Repositories;
using StorybaseApi.Services;
using System.Security.Cryptography;
using System.Text;

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

        app.MapPost(EndpointStrings.ResultUrlPaynow, async (IPaymentsRepository payments, PayNowService payNowService, HttpRequest request) =>
        {
            var form = await request.ReadFormAsync();

            // Extract form values
            var reference = form["reference"].ToString();
            var paynowReference = form["paynowreference"].ToString();
            var status = form["status"].ToString();
            var amount = form["amount"].ToString();
            var pollurl = form["pollurl"].ToString();
            var receivedHash = form["hash"].ToString();

            // Update payment & purchase if paid
            if (status.ToLower().Equals("paid"))
            {
                await payNowService.AddPurchaseAndPayment(pollurl, reference, paynowReference);
            }
            else
            {
                // Log failed payment
                var payment = await payments.GetPaymentByPollLink(pollurl);
                payment.PaymentStatus = PaymentStatus.Failed;
                payment.Reference = "Payment failed";
                await payments.UpdateAsync(payment);
            }

            return Results.Ok();
        });

        return app;
    }
}
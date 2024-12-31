using Storybase.Core;
using Storybase.Core.DTOs;
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

        app.MapPost("/api/payment/result", async (HttpRequest request) =>
        {
            var form = await request.ReadFormAsync();

            // Extract form values
            var reference = form["reference"].ToString();
            var status = form["status"].ToString();
            var amount = form["amount"].ToString();
            var receivedHash = form["hash"].ToString();

            // Validate hash
            var expectedHash = ComputeHash(reference, status, amount, "YourIntegrationKey");
            if (receivedHash != expectedHash)
            {
                return Results.BadRequest("Invalid hash.");
            }

            // Process payment status
            if (status == "Paid")
            {
                // Update order status in your database
                await UpdateOrderStatus(reference, "Paid");
            }
            else
            {
                // Handle other statuses (e.g., "Cancelled", "Failed")
                await UpdateOrderStatus(reference, status);
            }

            return Results.Ok();
        });

        // Helper method to compute hash
        string ComputeHash(string reference, string status, string amount, string integrationKey)
        {
            var data = $"{reference}{status}{amount}";
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(integrationKey));
            return BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(data))).Replace("-", "").ToLower();
        }

        // Placeholder for updating the order status in the database
        async Task UpdateOrderStatus(string reference, string status)
        {
            // Simulate database update
            Console.WriteLine($"Order {reference} updated to status: {status}");
            await Task.CompletedTask;
        }

        return app;
    }
}
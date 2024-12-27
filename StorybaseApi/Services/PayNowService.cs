using Storybase.Core.DTOs;
using Webdev.Payments;

namespace StorybaseApi.Services;

public class PayNowService
{
    private readonly IConfiguration _configuration;
    private PaymentInitResponseDto paymentResponse;

    public PayNowService(IConfiguration configuration)
    {
        _configuration = configuration;
        paymentResponse = new();
    }

    public async Task<PaymentInitResponseDto> InitializePayment(PaymentRequestDto paymentRequest)
    {
        // Fetch credentials from config
        var integrationId = _configuration["PayNow:IntegrationId"];
        var integrationKey = _configuration["PayNow:IntegrationKey"];
        var returnUrl = _configuration["PayNow:ReturnUrl"];
        var resultUrl = _configuration["PayNow:ResultUrl"];

        var paynow = new Paynow(integrationId, integrationKey);
        paynow.ReturnUrl = returnUrl;
        paynow.ResultUrl = resultUrl;

        // Create a new payment
        var payment = paynow.CreatePayment(paymentRequest.Title, paymentRequest.UserEmail);

        // Add payment details
        payment.Add(paymentRequest.Title, paymentRequest.Amount);

        // Send payment to PayNow
        var response = await paynow.SendAsync(payment);

        if (response.Success())
        {
            // Get the url to redirect the user to so they can make payment
            paymentResponse.RedirectLink = response.RedirectLink();

            // Get the poll url (used to check the status of a transaction). You might want to save this in your DB
            paymentResponse.PollUrl = response.PollUrl();
            paymentResponse.IsSuccess = true;
        }
        else
        {
            paymentResponse.IsSuccess = false;
        }
        return paymentResponse;
    }

    public async Task<PaymentCheckResponseDto> CheckPaymentStatus(string pollUrl)
    {
        PaymentCheckResponseDto paymentCheckResponse = new();

        var paynow = new Paynow(
            _configuration["PayNow:IntegrationId"],
            _configuration["PayNow:IntegrationKey"]
        );

        var response = paynow.PollTransaction(pollUrl);

        if (response.Success())
        {
            paymentCheckResponse.IsSuccess = true;
            paymentCheckResponse.Amount = response.Amount;
            paymentCheckResponse.Reference = response.Reference;
            paymentCheckResponse.PollUrl = response.PollUrl();
        }
        else
        {
            paymentCheckResponse.IsSuccess = false;
            paymentCheckResponse.Errors = response.Errors();
        }

        return paymentCheckResponse;
    }

    public async Task<PaymentInitResponseDto> InitializeMobilePayment(PaymentRequestDto paymentRequest)
    {
        var paynow = new Paynow(
            _configuration["PayNow:IntegrationId"],
            _configuration["PayNow:IntegrationKey"]
        );
        var payment = paynow.CreatePayment(paymentRequest.Title, paymentRequest.UserEmail);
        payment.Add(paymentRequest.Title, paymentRequest.Amount);
        var response = await paynow.SendMobileAsync(payment, paymentRequest.PhoneNumber, paymentRequest.MobileGateway.ToString());
        if (response.Success())
        {
            paymentResponse.RedirectLink = response.RedirectLink();
            paymentResponse.PollUrl = response.PollUrl();
            paymentResponse.IsSuccess = true;
        }
        else
        {
            paymentResponse.IsSuccess = false;
        }
        return paymentResponse;
    }
}


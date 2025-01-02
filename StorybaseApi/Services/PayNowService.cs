using Azure;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;
using Webdev.Payments;

namespace StorybaseApi.Services;

public class PayNowService
{
    private readonly IConfiguration _configuration;
    private PaymentInitResponseDto paymentResponse;
    private IPurchaseRepository purchaseRepository;
    private IPaymentsRepository paymentsRepository;
    private IUserRepository userRepository;

    public PayNowService(IConfiguration configuration, 
            IPurchaseRepository _purchaseRepository, 
            IPaymentsRepository _payments,
            IUserRepository _userRepository)
    {
        _configuration = configuration;
        paymentResponse = new();
        purchaseRepository = _purchaseRepository;
        paymentsRepository = _payments;
        userRepository = _userRepository;
    }

    public async Task<PaymentInitResponseDto> InitializePayment(PaymentRequestDto paymentRequest)
    {
        // Fetch credentials from config
        //TODO: Log purchases and payments after successful payment on the server
        var integrationId = _configuration["PayNow:IntegrationId"];
        var integrationKey = _configuration["PayNow:IntegrationKey"];
        var returnUrl = _configuration["PayNow:ReturnUrl"];
        var resultUrl = _configuration["PayNow:ResultUrl"];

        var paynow = new Paynow(integrationId, integrationKey);

        paynow.ResultUrl = resultUrl;
        //Create new guid for the transaction id
        var transactionId = Guid.NewGuid();
        paynow.ReturnUrl = $"{returnUrl}/{transactionId}";

        // Create a new payment
        var payment = paynow.CreatePayment(paymentRequest.Title, paymentRequest.UserEmail);

        // Add payment details
        payment.Add(paymentRequest.Title, paymentRequest.Amount);

        // Send payment to PayNow
        var response = await paynow.SendAsync(payment);

        //So once a payment is initiated, log the payment details to the database
        Payments payments = new Payments
        {
            UserId = await userRepository.GetUserId(paymentRequest.UserAuthId),
            Title = paymentRequest.LiteraryWorkPurchasedId.ToString(),
            Amount = paymentRequest.Amount,
            PaymentStatus = PaymentStatus.Pending,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            PollUrl = response.PollUrl(),
            Reference = $"{DateTime.Now}: {paymentRequest.LiteraryWorkPurchasedId}",
            TransactionId = transactionId
        };

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
            payments.PaymentStatus = PaymentStatus.Failed;
            //Reference holds the errors that occurred during the transaction
            payments.Reference = response.Errors();
        }
        //Save the payment details to the database
        await paymentsRepository.AddAsync(payments);

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
            paymentCheckResponse.WasPaid = response.WasPaid;

            if (response.WasPaid)
            {
                //First check in the database if the payment has already been paid through the result url
                var payment = await paymentsRepository.GetPaymentByPollLink(pollUrl);
                if (payment.PaymentStatus == PaymentStatus.Paid)
                {
                    paymentCheckResponse.IsSuccess = true;
                    paymentCheckResponse.WasPaid = true;
                    paymentCheckResponse.Errors = "Payment already made";
                }
                else
                {
                    await AddPurchaseAndPayment(pollUrl, paymentCheckResponse.Reference);
                }
            }
            else
            {
                //Update payment status to not paid
                var payment = await paymentsRepository.GetPaymentByPollLink(pollUrl);
                payment.PaymentStatus = PaymentStatus.NotPaid;
                payment.UpdatedAt = DateTime.Now;
                payment.Reference = response.Errors();
                await paymentsRepository.UpdateAsync(payment);
            }
        }
        else
        {
            //Update payment status to failed
            var payment = await paymentsRepository.GetPaymentByPollLink(pollUrl);
            payment.PaymentStatus = PaymentStatus.Failed;
            payment.UpdatedAt = DateTime.Now;
            payment.Reference = response.Errors();
            await paymentsRepository.UpdateAsync(payment);

            paymentCheckResponse.IsSuccess = false;
            paymentCheckResponse.WasPaid = response.WasPaid;
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

    //Method to add purchase and update payment to the database
    public async Task AddPurchaseAndPayment(string pollUrl, string reference, string payNowReference = "")
    {
        //Update the payment in the database
        var payment = await paymentsRepository.GetPaymentByPollLink(pollUrl);
        payment.PaymentStatus = PaymentStatus.Paid;
        payment.UpdatedAt = DateTime.Now;
        payment.Reference = reference;
        payment.PayNowReference = payNowReference; 
        await paymentsRepository.UpdateAsync(payment);

        //Add the purchased literary work to the user's account
        var purchase = new PurchasesDto
        {
            UserId = payment.UserId,
            LiteraryWorkId = int.Parse(payment.Title),
            Amount = payment.Amount,
            PurchaseDate = DateTime.Now
        };
        await purchaseRepository.AddPurchaseAfterPayment(purchase);
    }
}


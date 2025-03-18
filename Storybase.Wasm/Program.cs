using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using Storybase.Application.Interfaces;
using Storybase.Application.Services;
using Storybase.Components.Services;
using Storybase.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var environment = args.Contains("--local") ? Environments.Development : Environments.Production;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.AddSingleton(config);


string? baseAddress = "";
// Api client registration
builder.Services.AddHttpClient<IApiClient, ApiClient>("Storybase", client =>
{
    if (environment == Environments.Development)
    {
        baseAddress = builder.Configuration["Endpoints:Local"];
    }
    else
    {
        baseAddress = builder.Configuration["Endpoints:Online"];
    }
    client.BaseAddress = new Uri(baseAddress);
});

// Auth0 Blazor WASM Code
builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = builder.Configuration["Auth0:Authority"];
    options.ProviderOptions.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ProviderOptions.ResponseType = "code";
});


//Repository registrations  
builder.Services.AddScoped<BookmarkClient>();
builder.Services.AddScoped<ChapterClient>();
builder.Services.AddScoped<LiteraryWorkClient>();
builder.Services.AddScoped<PurchaseClient>();
builder.Services.AddScoped<ReadingProgressClient>();
builder.Services.AddScoped<LibraryClient>();
builder.Services.AddScoped<UserClient>();
builder.Services.AddScoped<WriterClient>();
builder.Services.AddScoped<GenresClient>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DialogHelperService>();
builder.Services.AddScoped<PayNowClient>();
builder.Services.AddScoped<PaymentsClient>();
builder.Services.AddScoped<PayoutRequestsClient>();
builder.Services.AddScoped<SalesClient>();
builder.Services.AddScoped<UserPayoutMethodsClient>();
builder.Services.AddScoped<GeneralClient>();


builder.Services.AddCascadingAuthenticationState();
builder.Services.AddMudServices();

await builder.Build().RunAsync();

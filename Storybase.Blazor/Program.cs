using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MudBlazor.Services;
using Storybase.Application.Interfaces;
using Storybase.Application.Services;
using Storybase.Blazor;
using Storybase.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient<IApiClient, ApiClient>("StorybaseApiClient", client =>
{
    var baseAddress = builder.Configuration["StorybaseApiEndpoint"];
    if (string.IsNullOrEmpty(baseAddress))
    {
        throw new ArgumentNullException(nameof(baseAddress), "StorybaseApiEndpoint configuration is missing or empty.");
    }
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddMudServices();
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

//Repository registrations  
builder.Services.AddScoped<BookmarkClient>();
builder.Services.AddScoped<ChapterClient>();
builder.Services.AddScoped<LiteraryWorkClient>();
builder.Services.AddScoped<PurchaseClient>();
builder.Services.AddScoped<ReadingProgressClient>();
builder.Services.AddScoped<UserClient>();
builder.Services.AddScoped<WriterClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAntiforgery();

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
            .Build();

    await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    // Handle post-login logic
    if (httpContext.User.Identity?.IsAuthenticated == true)
    {
        // Extract user ID (sub claim)
        var userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new InvalidOperationException("User ID (sub claim) is not available.");
        }

        // Check if the user is new using custom claim or external API
        var isNewUserClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "https://yourapp.com/isNewUser");

        if (isNewUserClaim != null && bool.TryParse(isNewUserClaim.Value, out var isNewUser) && isNewUser)
        {
            //Extract username, email and auth0 user id
            var username = httpContext.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var email = httpContext.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            // Create a new user
            var user = new User
            {
                Name = username,
                Email = email,
                Auth0UserId = userId
            };

            try
            {
                // Save the user to the database
                await app.Services.GetRequiredService<UserClient>().AddUserAsync(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
            }
        }
    }
    else
    {
        // Optional: Handle unauthenticated scenario
        Console.WriteLine("User is not authenticated.");
    }
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();

    await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddAdditionalAssemblies(typeof(Storybase.Components._Imports).Assembly);

app.Run();

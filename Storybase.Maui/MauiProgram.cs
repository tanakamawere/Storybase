using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Storybase.Application.Interfaces;
using Storybase.Application.Services;
using Storybase.Components.Services;
using System.Reflection;

namespace Storybase.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
        builder.Services.AddMudServices();



        var executingAssembly = Assembly.GetExecutingAssembly();
        using var stream = executingAssembly.GetManifestResourceStream("Storybase.Maui.appsettings.json");

        var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();


        builder.Services.AddHttpClient<IApiClient, ApiClient>("StorybaseApiClient", client =>
        client.BaseAddress = new Uri("https://16b0-77-246-50-218.ngrok-free.app/"));

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddSingleton(new Auth.Auth0Client(new()
        {
            Domain = configuration["Auth0:Domain"],
            ClientId = configuration["Auth0:ClientId"],
            Scope = configuration["Auth0:Scopes"],
            RedirectUri = configuration["Auth0:RedirectUri"],
        }));

        //Registering services
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

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

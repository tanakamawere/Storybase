using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Storybase.Application.Interfaces;
using Storybase.Application.Services;
using Storybase.Components.Services;

namespace Storybase.Maui
{
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
            builder.Services.AddHttpClient<IApiClient, ApiClient>("StorybaseApiClient", client =>
            client.BaseAddress = new Uri("https://318c-77-246-55-166.ngrok-free.app/"));

            builder.Services.AddMauiBlazorWebView();

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
}

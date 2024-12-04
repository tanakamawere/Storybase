using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Storybase.Application.Services;

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
            builder.Services.AddHttpClient("StorybaseApiClient", client =>
            client.BaseAddress = new Uri("https://ndhwhzs1-7199.inc1.devtunnels.ms/"));

            builder.Services.AddMauiBlazorWebView();

            //Registering services
            builder.Services.AddScoped<BookmarkClient>();
            builder.Services.AddScoped<ChapterClient>();
            builder.Services.AddScoped<LiteraryWorkClient>();
            builder.Services.AddScoped<PurchaseClient>();
            builder.Services.AddScoped<ReadingProgressClient>();
            builder.Services.AddScoped<UserClient>();
            builder.Services.AddScoped<WriterClient>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

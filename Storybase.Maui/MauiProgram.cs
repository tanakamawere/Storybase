using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;

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
            client.BaseAddress = new Uri("https://ee6c-154-120-240-26.ngrok-free.app/"));

            builder.Services.AddMauiBlazorWebView();

            //Registering services
            builder.Services.AddSingleton<IApiRepository, ApiRepository>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

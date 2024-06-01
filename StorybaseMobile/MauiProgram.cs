using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;
using StorybaseMobile.Pages;
using StorybaseMobile.Pages.Auth;
using StorybaseMobile.ViewModels;
using UraniumUI;

namespace StorybaseMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFontAwesomeIconFonts();
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://game-pelican-remotely.ngrok-free.app/")
            });

            //Viewmodel registration
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<ProfileViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<BookDetailsViewModel>();
            builder.Services.AddTransient<WriterPageViewModel>();
            builder.Services.AddTransient<ReadingViewModel>();

            // Pages registration
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddTransient<BookDetailsPage>();
            builder.Services.AddTransient<WriterViewPage>();
            builder.Services.AddTransient<ReadingPage>();

            //Services
            builder.Services.AddScoped<IApiRepository, ApiRepository>();


            return builder.Build();
        }
    }
}

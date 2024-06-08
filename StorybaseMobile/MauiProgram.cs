using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;
using StorybaseMobile.Pages;
using StorybaseMobile.Pages.Auth;
using StorybaseMobile.ViewModels;
using The49.Maui.BottomSheet;
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
                .UseBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    //add lora, merriweather, and roboto fonts
                    fonts.AddFont("Lora.ttf", "Lora");
                    fonts.AddFont("Roboto.ttf", "Roboto"); 
                    fonts.AddFont("Merriweather.ttf", "Merriweather");
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
            builder.Services.AddTransient<SignUpAsWriterViewModel>();
            builder.Services.AddTransient<SearchViewModel>();

            // Pages registration
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddTransient<BookDetailsPage>();
            builder.Services.AddTransient<WriterViewPage>();
            builder.Services.AddTransient<ReadingPage>();
            builder.Services.AddTransient<SignUpAsWriterPage>();
            builder.Services.AddTransient<SearchPage>();

            //Services
            builder.Services.AddSingleton<IApiRepository, ApiRepository>();

            return builder.Build();
        }
    }
}

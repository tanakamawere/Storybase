using StorybaseMobile.Pages;
using StorybaseMobile.Pages.Auth;
using StorybaseMobile.Views;

namespace StorybaseMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(BookDetailsPage), typeof(BookDetailsPage));
            Routing.RegisterRoute(nameof(WriterViewPage), typeof(WriterViewPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(ReadingPage), typeof(ReadingPage));
            Routing.RegisterRoute(nameof(SignUpAsWriterPage), typeof(SignUpAsWriterPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));

            Routing.RegisterRoute(nameof(ReadingSettingsView), typeof(ReadingSettingsView));
        }
    }
}

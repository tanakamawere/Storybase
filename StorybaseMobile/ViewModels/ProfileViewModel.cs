using StorybaseMobile.Pages.Auth;

namespace StorybaseMobile.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    public ProfileViewModel()
    {
        Title = "Profile";
    }

    //Go to login page
    [RelayCommand]
    public async Task GoToLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}

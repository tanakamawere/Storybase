using CommunityToolkit.Maui.Alerts;
using StorybaseMobile.Pages;
using StorybaseMobile.Pages.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StorybaseMobile.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    [ObservableProperty]
    private string name = "Not Logged In";
    [ObservableProperty]
    private string email = "Not Logged In";
    [ObservableProperty]
    private string phoneNumber = "Not Logged In";
    [ObservableProperty]
    private bool isLoggedIn = false;
    [ObservableProperty]
    private string userRole = "Something here";

    public ProfileViewModel()
    {
        Title = "Profile";
    }

    //Check for token in secure storage
    [RelayCommand]
    public async Task CheckToken()
    {
        try
        {
            var token = await SecureStorage.GetAsync("auth_token");

            if (token != null)
            {
                IsLoggedIn = true;
                //Decode the claims from the token
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var claims = jsonToken.Claims;
                if (claims != null)
                {
                    foreach (var claim in claims)
                    {
                        if (claim.Type == "unique_name")
                        {
                            Name = claim.Value;
                        }
                        else if (claim.Type == ClaimTypes.MobilePhone)
                        {
                            PhoneNumber = claim.Value;
                        }
                        else if (claim.Type == "role")
                        {
                            UserRole = claim.Value;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    //Go to login page
    [RelayCommand]
    public async Task GoToLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    //Logout user
    [RelayCommand]
    public async Task Logout()
    {
        bool success = SecureStorage.Default.Remove("auth_token");

        if (success)
        {
            IsLoggedIn = false;
            Name = "Not Logged In";
            Email = "Not Logged In";
            PhoneNumber = "Not Logged In";

            //Show toast and navigate to homepage, pop all pages
            await Toast.Make("Logged Out", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

    //Go To Sign up as writer page
    [RelayCommand]
    public async Task GoToSignUpAsWriter()
    {
        //First check if user is logged in
        if (IsLoggedIn)
        {
            //Go to sign up as writer page sending the user object
            await Shell.Current.GoToAsync($"{nameof(SignUpAsWriterPage)}?userName={Name}");
        }
        else
        {
            await Toast.Make("Please login to sign up as a writer", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}

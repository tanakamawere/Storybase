using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using StorybaseMobile.Pages.Auth;
using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private LoginUserRequest userRequest;

    public LoginViewModel(IApiRepository apiRepository)
    {
        this.apiRepository = apiRepository;
        userRequest = new LoginUserRequest();
    }

    [RelayCommand]
    public async Task LoginUserAsync()
    {
        if (UserRequest.PhoneNumber == null || UserRequest.Password == null)
        {
            //Display toast of error message
            var toast = Toast.Make("Please enter your phone number and password", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        try
        {
            IsBusy = true;
            var response = await apiRepository.LoginUserAsync(UserRequest);
            if (response.Token != null)
            {
                await SecureStorage.SetAsync("auth_token", response.Token);
            }
            else
            {
                //Display toast of error message
                var toast = Toast.Make(response.Message, ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    //Go to Register Page
    [RelayCommand]
    public async Task RegisterUserAsync()
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}

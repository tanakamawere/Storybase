using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using StorybaseMobile.Pages.Auth;
using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    [ObservableProperty]
    private RegisterUserDto userDto;
    [ObservableProperty]
    private string confirmPassword;
    public RegisterViewModel(IApiRepository apiRepository)
    {
        this.apiRepository = apiRepository;
        userDto = new RegisterUserDto();
    }

    [RelayCommand]
    public async Task RegisterUserAsync()
    {
        if (UserDto.PhoneNumber == null || UserDto.Password == null || ConfirmPassword == null)
        {
            //Display toast of error message
            var toast = Toast.Make("Please enter your phone number, password and confirm password", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        if (UserDto.Password != ConfirmPassword)
        {
            //Display toast of error message
            var toast = Toast.Make("Passwords do not match", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        try
        {
            IsBusy = true;
            var response = await apiRepository.RegisterUserAsync(UserDto);
            if (response.Message == "new_user")
            {
                var toast = Toast.Make("Account made successfully. Now login", ToastDuration.Short, 14);
                await toast.Show();
                await Shell.Current.GoToAsync(nameof(LoginPage));
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
}

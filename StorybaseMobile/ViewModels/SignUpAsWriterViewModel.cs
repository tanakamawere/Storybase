using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MvvmHelpers;
using StorybaseMobile.Pages;
using StorybaseMobile.Views;
using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(Username), "userName")]
public partial class SignUpAsWriterViewModel : BaseViewModel
{
    [ObservableProperty]
    private WriterDto writer;
    [ObservableProperty]
    private string username;

    public SignUpAsWriterViewModel(IApiRepository api, IPopupService popup)
    {
        apiRepository = api;
        popupService = popup;
        loadingView = new LoadingView();
        writer = new();
        Writer.UserName = Username;
    }

    // This method is called when the user taps the "Save" button
    [RelayCommand]
    public async Task SaveWriterAsync()
    {
        //await popupService.ShowPopupAsync(loadingView);
        try
        { 
            Writer.UserName = Username;

            if (await apiRepository.CreateWriterSignupAsync(Writer))
            {
                await Toast.Make("You have signed up as a writer!", ToastDuration.Long)
                    .Show();
            }
            else 
            {
                await Toast.Make("Something went wrong...").Show();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Toast.Make("An error occurred while signing up as a writer. Please try again later.", ToastDuration.Long)
                .Show();
        }
        finally
        {
            //await loadingView.CloseAsync();
            //Go to previous page
            await Shell.Current.GoToAsync("//..");
        }
    }
}

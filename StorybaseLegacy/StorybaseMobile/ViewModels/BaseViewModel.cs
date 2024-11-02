using CommunityToolkit.Maui.Core;
using StorybaseMobile.Pages;
using StorybaseMobile.Views;

namespace StorybaseMobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;
    [ObservableProperty]
    private string title = string.Empty;
    public IApiRepository apiRepository;
    public IPopupService popupService;
    public LoadingView loadingView;


    [RelayCommand]
    public async Task GoToBookDetails(Book book)
    {
        if (book != null)
        {
            await Shell.Current.GoToAsync(nameof(BookDetailsPage), true, new Dictionary<string, object>
            {
                { "bookSelected", book }
            });
        }
    }

    // Command to go to the writer's page
    [RelayCommand]
    public async Task GoToWriter(Writer writer)
    {
        if (writer != null)
        {
            await Shell.Current.GoToAsync(nameof(WriterViewPage), true, new Dictionary<string, object>
            {
                { "writerSelected", writer }
            });
        }
    }
}

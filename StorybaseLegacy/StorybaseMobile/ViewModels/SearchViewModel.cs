using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace StorybaseMobile.ViewModels;

public partial class SearchViewModel : BaseViewModel
{
    private SearchResults searchResults;

    [ObservableProperty]
    private List<Writer> writers = new();
    [ObservableProperty]
    private List<Book> books = new();

    [ObservableProperty]
    private string searchTerm;

    public SearchViewModel(IApiRepository repo, IPopupService popup)
    {
        apiRepository = repo;
        popupService = popup;
        loadingView = new();
    }

    [RelayCommand]
    public async Task Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            await Toast.Make("Please enter a search term.").Show();
            return;
        }

        IsBusy = true;

        try
        {
            Writers.Clear();
            Books.Clear();
            searchResults = await apiRepository.SearchAsync(query);
            Writers = searchResults.Writers;
            Books = searchResults.Books;
        }
        catch (Exception ex)
        {
            await Toast.Make(ex.Message).Show();
        }
        finally
        {
            IsBusy = false;
        }
    }
}

using StorybaseMobile.Pages;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(WriterSelected), "writerSelected")]
public partial class WriterPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private Writer writerSelected;

    public WriterPageViewModel(IApiRepository api)
    {
        apiRepository = api;
    }

    [RelayCommand]
    public async Task LoadWriter()
    {
        if (WriterSelected != null)
        {
            WriterSelected = await apiRepository.GetWriterProfileAsync(writerSelected.Id);
        }
    }

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
}

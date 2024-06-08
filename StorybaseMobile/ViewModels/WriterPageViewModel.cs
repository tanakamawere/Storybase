using MvvmHelpers;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(WriterSelected), "writerSelected")]
public partial class WriterPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private Writer writerSelected;
    public ObservableRangeCollection<Book> Books { get; set; } = new();

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
            Books.ReplaceRange(WriterSelected.Books);
        }
    }
}

using MvvmHelpers;
using StorybaseMobile.Pages;
using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(BookSelected), "bookSelected")]
public partial class BookDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private Book bookSelected;
    public ObservableRangeCollection<Chapter> Chapters { get; set; } = new();

    public BookDetailsViewModel(IApiRepository api)
    {
        apiRepository = api;
    }

    [RelayCommand]
    public async Task GetBookDetails()
    {
        IsBusy = true;
        Chapters.Clear();
        try
        {
            BookSelected = await apiRepository.GetBookByIdAsync(BookSelected.Id);
            Chapters.Clear();
            Chapters.AddRange(BookSelected.Chapters);
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

    // Command to go to the chapter's page
    [RelayCommand]
    public async Task GoToChapter(Chapter chapter)
    {
        if (chapter != null)
        {
            await Shell.Current.GoToAsync(nameof(ReadingPage), true, new Dictionary<string, object>
            {
                { "chapterSelected", chapter }
            });
        }
    }
}

using System.Diagnostics;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(ChapterSelected), "chapterSelected")]
public partial class ReadingViewModel : BaseViewModel
{
    [ObservableProperty]
    private Chapter chapterSelected;

    public ReadingViewModel(IApiRepository api)
    {
        apiRepository = api;
    }

    [RelayCommand]
    public async Task GetChapterDetails()
    {
        IsBusy = true;
        try
        {
            ChapterSelected = await apiRepository.GetChapterByIdAsync(ChapterSelected.Id);
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

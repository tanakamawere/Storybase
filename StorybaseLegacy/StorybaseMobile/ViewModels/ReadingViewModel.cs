using CommunityToolkit.Maui.Core;
using StorybaseMobile.Views;
using System.Diagnostics;
using The49.Maui.BottomSheet;

namespace StorybaseMobile.ViewModels;

[QueryProperty(nameof(ChapterSelected), "chapterSelected")]
public partial class ReadingViewModel : BaseViewModel
{
    [ObservableProperty]
    private Chapter chapterSelected;

    public ReadingViewModel(IApiRepository api, IPopupService service)
    {
        apiRepository = api;
        popupService = service;
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

    //Relay command to open the settings bottom sheet
    [RelayCommand]
    public async Task OpenSettingsBottomSheet()
    {
        await popupService.ShowPopupAsync<ReadingSettingsView>();
    }
}

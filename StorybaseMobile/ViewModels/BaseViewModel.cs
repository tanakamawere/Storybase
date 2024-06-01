using CommunityToolkit.Mvvm.ComponentModel;
using StorybaseLibrary.Interfaces;

namespace StorybaseMobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;
    [ObservableProperty]
    private string title = string.Empty;
    public IApiRepository apiRepository;
}

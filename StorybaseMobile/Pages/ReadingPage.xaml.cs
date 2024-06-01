using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class ReadingPage : ContentPage
{
	public ReadingPage(ReadingViewModel readingViewModel)
	{
		InitializeComponent();

		BindingContext = readingViewModel;
	}
}
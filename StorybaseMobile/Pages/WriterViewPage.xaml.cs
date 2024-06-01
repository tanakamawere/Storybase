using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class WriterViewPage : ContentPage
{
	public WriterViewPage(WriterPageViewModel writerPageViewModel)
	{
		InitializeComponent();

		BindingContext = writerPageViewModel;
	}
}
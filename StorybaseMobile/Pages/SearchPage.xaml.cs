using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel searchViewModel)
	{
		InitializeComponent();
		BindingContext = searchViewModel;
	}
}
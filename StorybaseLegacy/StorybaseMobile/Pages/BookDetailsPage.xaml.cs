using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class BookDetailsPage : ContentPage
{
	public BookDetailsPage(BookDetailsViewModel bookDetailsViewModel)
	{
		InitializeComponent();

		BindingContext = bookDetailsViewModel;
	}
}
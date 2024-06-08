using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class SignUpAsWriterPage : ContentPage
{
	public SignUpAsWriterPage(SignUpAsWriterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
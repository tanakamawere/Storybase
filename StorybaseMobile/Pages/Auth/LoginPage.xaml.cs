using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
using StorybaseMobile.ViewModels;

namespace StorybaseMobile.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();

		BindingContext = profileViewModel;
	}
}
using static System.Net.Mime.MediaTypeNames;

namespace StorybaseMobile.Templates;

public partial class ProfileButtonTemplate : Border
{
    public static readonly BindableProperty IconProperty = BindableProperty
        .Create(nameof(Text), typeof(string), typeof(ProfileButtonTemplate), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ProfileButtonTemplate)bindable;
            control.profileButtonIcon.Glyph = newValue as string;
        });
    public static readonly BindableProperty TitleProperty = BindableProperty
        .Create(nameof(Title), typeof(string), typeof(ProfileButtonTemplate), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ProfileButtonTemplate)bindable;
            control.profileButtonLabel.Text = newValue as string;
        });

    public ProfileButtonTemplate()
    {
        InitializeComponent();
    }
    public string Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }
    public string Icon
    {
        get => GetValue(IconProperty) as string;
        set => SetValue(IconProperty, value);
    }

}
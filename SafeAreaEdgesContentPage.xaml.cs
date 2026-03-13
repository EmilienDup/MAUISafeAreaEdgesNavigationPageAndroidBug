namespace MAUISafeAreaEdgesNavigationPageAndroidBug;

public partial class SafeAreaEdgesContentPage
{
    public SafeAreaEdgesContentPage()
    {
        InitializeComponent();
    }

    private void BackButton_OnClicked(
        object? sender,
        EventArgs e)
    {
        Application.Current?.Windows[0].Page = new NavigationPage(new MainPage());
    }
}
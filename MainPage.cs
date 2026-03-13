namespace MAUISafeAreaEdgesNavigationPageAndroidBug;

public class MainPage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            var setAsMainPage = await this.DisplayAlertAsync("Launcher", "How to navigate to the testing page?", "Set as main page", "Navigation");

            var page = new SafeAreaEdgesContentPage();
            if (setAsMainPage)
            {
                Application.Current?.Windows[0].Page = page;
            }
            else
            {
                await this.Navigation.PushAsync(page);
            }
        });
    }
}
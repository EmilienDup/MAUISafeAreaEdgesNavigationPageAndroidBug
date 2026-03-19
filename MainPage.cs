namespace MAUISafeAreaEdgesNavigationPageAndroidBug;

public class MainPage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        this.NavigateToPage();
    }

    private void NavigateToPage()
    {
        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            string action = await DisplayActionSheetAsync("Navigation Mode", "Cancel", null, "Main page", "Push to Stack", "Modal");

            var page = new SafeAreaEdgesContentPage();
            if (action == "Main page")
            {
                Application.Current?.Windows[0].Page = page;
            }
            else if (action == "Push to Stack")
            {
                await this.Navigation.PushAsync(page);
            }
            else if (action == "Modal")
            {
                await this.Navigation.PushModalAsync(page);
            }
            else
            {
                this.NavigateToPage();
            }
        });
    }
}
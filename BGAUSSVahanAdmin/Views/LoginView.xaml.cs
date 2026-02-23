using Microsoft.Identity.Client;

namespace BGAUSSVahanAdmin.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            if (MauiProgram.PCA == null)
            {
                await DisplayAlert("Error", "Authentication not initialized.", "OK");
                return;
            }

            var scopes = new[] { "User.Read" };

#if ANDROID
            var parentWindow = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
#endif

            var result = await MauiProgram.PCA
                .AcquireTokenInteractive(scopes)
#if ANDROID
                .WithParentActivityOrWindow(parentWindow)
#endif
                .ExecuteAsync();

            //await DisplayAlert("Success", $"Welcome {result.Account.Username}", "OK");

            await Shell.Current.GoToAsync(nameof(DashboardView));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
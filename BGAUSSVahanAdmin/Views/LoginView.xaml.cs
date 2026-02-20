using Microsoft.Identity.Client;
using Microsoft.Maui.ApplicationModel;

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
            var scopes = new[] { "User.Read" };

            var result = await MauiProgram.PCA.AcquireTokenInteractive(scopes)
#if ANDROID
                              .WithParentActivityOrWindow(Platform.CurrentActivity)
#endif
                              .ExecuteAsync();

            await DisplayAlert("Success", $"Welcome {result.Account.Username}", "OK");

            // Navigate using Shell
            // Navigate on UI thread
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                // Absolute route (resets navigation stack)
                await Shell.Current.GoToAsync($"//{nameof(DashboardView)}");
            });
        }
        catch (MsalException msalEx)
        {
            await DisplayAlert("Error", msalEx.Message, "OK");
        }
    }
}

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
            if (MauiProgram.PCA == null)
            {
                await DisplayAlert("Error", "Authentication not initialized.", "OK");
                return;
            }

            var scopes = new[] { "User.Read" };

            var result = await MauiProgram.PCA
                .AcquireTokenInteractive(scopes)
#if ANDROID
                .WithParentActivityOrWindow(Platform.CurrentActivity)
#endif
                .ExecuteAsync();

            await DisplayAlert("Success", $"Welcome {result.Account.Username}", "OK");

            await Shell.Current.GoToAsync(nameof(DashboardView));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}

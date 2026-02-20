namespace BGAUSSVahanAdmin.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new DashboardView());
    }
}

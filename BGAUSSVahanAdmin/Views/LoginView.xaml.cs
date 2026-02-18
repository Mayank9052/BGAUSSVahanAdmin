namespace BGAUSSVahanAdmin.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Later you can add authentication logic here

        await Navigation.PushAsync(new DashboardView());
    }
}

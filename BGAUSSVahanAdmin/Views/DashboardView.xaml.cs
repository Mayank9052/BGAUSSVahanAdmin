namespace BGAUSSVahanAdmin.Views;

public partial class DashboardView : ContentPage
{
    public DashboardView()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        this.Opacity = 0;
        await this.FadeTo(1, 500);
    }

    private async void OnECatalogClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ECatalogView));
    }

    private async void OnReportsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Reports", "Reports Module Coming Soon", "OK");
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Profile", "User Profile Section", "OK");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginView");
    }
}
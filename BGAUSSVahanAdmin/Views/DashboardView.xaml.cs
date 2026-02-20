using System.Linq;

namespace BGAUSSVahanAdmin.Views;

public partial class DashboardView : ContentPage
{
    bool isSidebarOpen = false;
    bool isAnimating = false;

    public DashboardView()
    {
        InitializeComponent();

        Sidebar.TranslationX = -280;
        Overlay.Opacity = 0;
        Overlay.IsVisible = false;
    }

    private async void OnToggleSidebar(object sender, EventArgs e)
    {
        if (isAnimating) return;
        isAnimating = true;

        if (!isSidebarOpen)
        {
            Sidebar.IsVisible = true;
            Overlay.IsVisible = true;

            await Task.WhenAll(
                Sidebar.TranslateTo(0, 0, 250, Easing.CubicOut),
                Overlay.FadeTo(1, 250)
            );
        }
        else
        {
            await Task.WhenAll(
                Sidebar.TranslateTo(-280, 0, 250, Easing.CubicIn),
                Overlay.FadeTo(0, 250)
            );

            Sidebar.IsVisible = false;
            Overlay.IsVisible = false;
        }

        isSidebarOpen = !isSidebarOpen;
        isAnimating = false;
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Dashboard", "Dashboard selected", "OK");
    }

    private async void OnManageUsersClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Manage Users", "Open Manage Users Page", "OK");
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        var window = Application.Current?.Windows.FirstOrDefault();
        if (window != null)
            window.Page = new NavigationPage(new LoginView());
    }
}

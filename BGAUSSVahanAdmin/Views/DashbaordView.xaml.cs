using System.Linq;

namespace BGAUSSVahanAdmin.Views;

public partial class DashboardView : ContentPage
{
    bool isSidebarOpen = false;

    public DashboardView()
    {
        InitializeComponent();
    }

    private async void OnToggleSidebar(object sender, EventArgs e)
    {
        if (!isSidebarOpen)
        {
            Sidebar.IsVisible = true;
            Overlay.IsVisible = true;

            Sidebar.TranslationX = -260;

            await Task.WhenAll(
                Sidebar.TranslateToAsync(0, 0, 250, Easing.CubicOut),
                Overlay.FadeToAsync(1, 250)
            );
        }
        else
        {
            await Task.WhenAll(
                Sidebar.TranslateToAsync(-260, 0, 250, Easing.CubicIn),
                Overlay.FadeToAsync(0, 250)
            );

            Sidebar.IsVisible = false;
            Overlay.IsVisible = false;
        }

        isSidebarOpen = !isSidebarOpen;
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        var window = Application.Current?.Windows.FirstOrDefault();

        if (window != null)
        {
            window.Page = new NavigationPage(new LoginView());
        }
    }
}

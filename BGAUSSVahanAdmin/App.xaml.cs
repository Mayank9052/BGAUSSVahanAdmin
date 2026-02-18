using BGAUSSVahanAdmin.Views;

namespace BGAUSSVahanAdmin;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        MainPage = new NavigationPage(new LoginView());
    }
}

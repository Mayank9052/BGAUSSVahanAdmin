using BGAUSSVahanAdmin.Views;

namespace BGAUSSVahanAdmin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(DashboardView), typeof(DashboardView));
            Routing.RegisterRoute(nameof(ECatalogView), typeof(ECatalogView));
        }
    }
}

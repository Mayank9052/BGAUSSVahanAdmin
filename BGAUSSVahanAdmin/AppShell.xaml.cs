using BGAUSSVahanAdmin.Views;

namespace BGAUSSVahanAdmin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register Dashboard route
            Routing.RegisterRoute(nameof(DashboardView), typeof(DashboardView));
        }
    }
}

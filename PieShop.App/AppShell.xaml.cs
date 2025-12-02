using PieShop.App.Views;

namespace PieShop.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PieDetailView), typeof(PieDetailView));
            Routing.RegisterRoute(nameof(CartView), typeof(CartView));
        }
    }
}

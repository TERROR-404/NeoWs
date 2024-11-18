namespace NeoWs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.AsteroidPage), typeof(Views.AsteroidPage));
        }
    }
}

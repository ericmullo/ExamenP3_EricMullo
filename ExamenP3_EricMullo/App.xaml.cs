namespace ExamenP3_EricMullo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.MainPage()); // Define la página principal
        }
    }
}

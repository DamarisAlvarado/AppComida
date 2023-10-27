namespace AppComida
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage navigationPage = new NavigationPage(new MainPage(new ViewModels.LoginViewModel()));
            Color color = Color.FromArgb("#0247FE");
            navigationPage.BarBackgroundColor = color;
            navigationPage.BarTextColor = new Color(255, 255, 255);

            MainPage = navigationPage;
        }
    }
}
namespace AppComida
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            // No mover es para ir directo al menu amel :) ;
            // AMEL a DAMARIS: Aquí agregue el viewmodel de tu ventana Menu
            await Navigation.PushAsync(new Menu(new ViewModels.MenuViewModel()));
        }
    }
}
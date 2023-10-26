using AppComida.ViewModels;

namespace AppComida
{
    public partial class MainPage : ContentPage
    {
<<<<<<< HEAD
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            // No mover es para ir directo al menu amel :) ;
            // AMEL a DAMARIS: Aquí agregue el viewmodel de tu ventana Menu
            await Navigation.PushAsync(new Menu(new ViewModels.MenuViewModel(Navigation)));
=======
        public MainPage(LoginViewModel lvm)
        {
            InitializeComponent();
            BindingContext = lvm;
>>>>>>> b43548807bbbd135cb02d98b14646178e1673c4f
        }
    }
}
using AppComida.ViewModels;

namespace AppComida
{
    public partial class MainPage : ContentPage
    {
        public MainPage(LoginViewModel lvm)
        {
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}
using AppComida.ViewModels;

namespace AppComida;

public partial class Menu : ContentPage
{
	// AMEL a DAMARIA: Aqu� se le pasa como contexto el viewmodel menu para que muestre la imagen de fondo
	public Menu(MenuViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    private async void lista_comida(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ListaMenu());
    }

	private async void acerca_de(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Acerca());
	}
}
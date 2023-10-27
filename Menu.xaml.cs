using AppComida.Services;
using AppComida.ViewModels;

namespace AppComida;

public partial class Menu : ContentPage
{
	// AMEL a DAMARIS: Este es tu clase con la interfaz.
	PersonajesApiService personajesApiService;

	// AMEL a DAMARIS: Aquí se le pasa como contexto el viewmodel menu para que muestre la imagen de fondo
	public Menu(MenuViewModel vm)
	{
		personajesApiService = new PersonajesApiService();
		InitializeComponent();
		BindingContext = vm;
	}
    private async void lista_comida(object sender, EventArgs e)
	{
        // AMEL a DAMARIS: Aqui le pasamos la interfaz a nuestro ListaMenu
          await Navigation.PushAsync(new ListaMenu(personajesApiService));
    }

	private async void acerca_de(object sender, EventArgs e)

	{
		 
		await Navigation.PushAsync(new Acerca());
	}
}
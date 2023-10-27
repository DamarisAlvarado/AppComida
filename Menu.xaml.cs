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
<<<<<<< HEAD


		await Navigation.PushAsync(new Acerca(Launcher.Default));

=======
		await Navigation.PushAsync(new Acerca(Launcher.Default));
>>>>>>> 7e844a9cfc3bb55196755aee485a35ec72061e1f
	}

    private async void comentario_(object sender, EventArgs e)

    {
        await Navigation.PushAsync(new Comentario());
    }
}
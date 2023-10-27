using AppComida.Services;

namespace AppComida;

public partial class ListaMenu : ContentPage
{

    private readonly IPersonajesMService _personajesMService;
    public ListaMenu(IPersonajesMService service)
	{
		InitializeComponent();
		_personajesMService = service;
	}

    private async void verPokemon(object sender, EventArgs e)
    {
        loading.IsVisible = true;

        var data = await _personajesMService.Obtener();
        listViewPersonajes.ItemsSource = data;

        loading.IsVisible = false;


    }
    public async void favAsync(object sender, EventArgs e)
    {
        await DisplayAlert("Favoritos", "Este personaje se agrego a favoritos", "OK");
    }
}
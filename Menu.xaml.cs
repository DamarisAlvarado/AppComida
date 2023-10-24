namespace AppComida;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private async void lista_comida(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ListaMenu());
    }

    //NO MODIFICAR SE CAMBIARA CUANDO ESTEN LISTOS LOS PAGES
    private async void Acerca_de(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ListaMenu());
    }

    private async void Comentarios(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ListaMenu());
    }

    private async void Contacto(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ListaMenu());
    }
}
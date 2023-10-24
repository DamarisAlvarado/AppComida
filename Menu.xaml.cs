using AppComida.ViewModels;

namespace AppComida;

public partial class Menu : ContentPage
{
	// AMEL a DAMARIA: Aquí se le pasa como contexto el viewmodel menu para que muestre la imagen de fondo
	public Menu(MenuViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
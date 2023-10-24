using AppComida.ViewModels;

namespace AppComida;

public partial class Contacto : ContentPage
{
	public Contacto(ContactoViewModel contactoViewModel)
	{
		InitializeComponent();
		BindingContext = contactoViewModel;
	}
}
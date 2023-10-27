using AppComida.ViewModels;

namespace AppComida;

public partial class Comentario : ContentPage
{
	public Comentario()
	{
		InitializeComponent();
        BindingContext = new Comentarios();
	}

    // Damaris a sam y amel no mover 

    // Esto se movio al Comentarios (ViewModel)
    /* private async void agregar_foto(object sender, EventArgs e)

    {
        var foto = await MediaPicker.PickPhotoAsync();
        if (foto != null) 
        {
            var memoriaStream = await foto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(()=> memoriaStream);
        }
    }*/
}
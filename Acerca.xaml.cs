namespace AppComida;

public partial class Acerca : ContentPage
{
    private readonly ILauncher launcher;

    public Acerca(ILauncher launcher)
	{
		InitializeComponent();
        this.launcher = launcher;
    }
    private async void btnwhatsapp(object sender, EventArgs e)
    {
        var Number = 811659756;
        var url = $"https://wa.me/{Number}?text=Hola mundo";
        await launcher.OpenAsync(url);

    }
}
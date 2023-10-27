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
        var Number = 8116597556;
        var url = $"https://wa.me/{Number}?text=Holamundo";
        await launcher.OpenAsync(url);

    }
}
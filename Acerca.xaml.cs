namespace AppComida;

public partial class Acerca : ContentPage
{
    private readonly ILauncher laucher;

    public Acerca(ILauncher laucher)
	{
		InitializeComponent();
        this.laucher = laucher;
    }
}
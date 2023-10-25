using AppComida.ViewModels;

namespace AppComida;

public partial class Componer : ContentPage
{
	IEmail email;
	public Componer(string _whom, IEmail email)
	{
		InitializeComponent();
		whom.Text = _whom;
		whom.IsEnabled = false;
		this.email = email;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (subject.Text.Length == 0)
		{
			await App.Current.MainPage.DisplayAlert("Atención", "Completa el siguiente campo", "Ok");
			return;
		}
        if (body.Text.Length == 0)
        {
            await App.Current.MainPage.DisplayAlert("Atención", "Completa el siguiente campo", "Ok");
            return;
        }

		await email.ComposeAsync(subject.Text, body.Text, whom.Text);
    }
}
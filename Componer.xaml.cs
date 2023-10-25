using AppComida.ViewModels;

namespace AppComida;

public partial class Componer : ContentPage
{
	public Componer(string _whom)
	{
		InitializeComponent();
		whom.Text = _whom;
		whom.IsEnabled = false;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (subject.Text == null)
		{
			await App.Current.MainPage.DisplayAlert("Atención", "Completa el siguiente campo", "Ok");
			subject.Focus();
			return;
		}
        if (body.Text == null)
        {
            await App.Current.MainPage.DisplayAlert("Atención", "Completa el siguiente campo", "Ok");
            body.Focus();
            return;
        }

		await Email.Default.ComposeAsync(subject.Text, body.Text, whom.Text);
    }
}
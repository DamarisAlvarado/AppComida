﻿namespace AppComida
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);


            // No mover es para ir directo al menu amel :) ;
            // AMEL a DAMARIS: Aquí agregue el viewmodel de tu ventana Menu
            await Navigation.PushAsync(new Menu(new ViewModels.MenuViewModel()));
        }
    }
}
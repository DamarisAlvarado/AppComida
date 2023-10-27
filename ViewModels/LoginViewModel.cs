using Firebase.Auth.Providers;
using Firebase.Auth;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppComida.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        FirebaseAuthClient client;
        public Command AnonymousSignIn { get; }
        public Command EmailSignIn { get; }

        string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyBbZwbPPphYoPmzUjS-69jxahwM4jrcbww",
                AuthDomain = "comidaapp-677d2.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                    new GoogleProvider(),
                    new TwitterProvider(),
                    new FacebookProvider(),
                    new AppleProvider(),
                    new GithubProvider(),
                    new MicrosoftProvider()
                }
            };
            client = new FirebaseAuthClient(config);

            AnonymousSignIn = new Command(SignInAsAnonymous);
            EmailSignIn = new Command(SignInWithEmailProvider);
        }

        #region INICIO DE SESION ANONIMO
        public async void SignInAsAnonymous(object obj)
        {
            App.Current.MainPage.IsBusy = true;
            App.Current.MainPage.IsEnabled = false;
            var userCredential = await client.SignInAnonymouslyAsync();
            var user = userCredential.User;

            if (user == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error al iniciar sesion", "Ok");
                App.Current.MainPage.IsBusy = false;
                App.Current.MainPage.IsEnabled = true;
                return;
            }
            App.Current.MainPage.IsBusy = false;
            App.Current.MainPage.IsEnabled = true;
            await App.Current.MainPage.Navigation.PushAsync(new Menu(new MenuViewModel()));
        }
        #endregion

        #region INICIO DE SESION CON EMAIL
        public async void SignInWithEmailProvider(object obj)
        {
            App.Current.MainPage.IsBusy = true;
            App.Current.MainPage.IsEnabled = false;
            if (Email != null && Password != null)
            {
                if(Password.Length < 8)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "La contraseña es muy corta", "Ok");
                    App.Current.MainPage.IsBusy = false;
                    App.Current.MainPage.IsEnabled = true;
                    return;
                }

                UserCredential userCredential;
                try
                {
                    userCredential = await client.SignInWithEmailAndPasswordAsync(Email, Password);
                    var user = userCredential.User;
                    if (user == null)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Error al iniciar sesion", "Ok");
                        App.Current.MainPage.IsBusy = false;
                        App.Current.MainPage.IsEnabled = true;
                        return;
                    }
                    App.Current.MainPage.IsBusy = false;
                    App.Current.MainPage.IsEnabled = true;
                    await App.Current.MainPage.Navigation.PushAsync(new Menu(new MenuViewModel()));
                }
                catch
                {
                    try
                    {
                        userCredential = await client.CreateUserWithEmailAndPasswordAsync(Email, Password);
                        var user = userCredential.User;
                        if (user == null)
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Error al iniciar sesion", "Ok");
                            App.Current.MainPage.IsBusy = false;
                            App.Current.MainPage.IsEnabled = true;
                            return;
                        }
                        App.Current.MainPage.IsBusy = false;
                        App.Current.MainPage.IsEnabled = true;
                        await App.Current.MainPage.Navigation.PushAsync(new Menu(new MenuViewModel()));
                    }
                    catch
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "El correo ya existe o la contraseña es muy debil", "Ok");
                    }
                }
                App.Current.MainPage.IsBusy = false;
                App.Current.MainPage.IsEnabled = true;
                return;
            }
            App.Current.MainPage.IsBusy = false;
            App.Current.MainPage.IsEnabled = true;
            await App.Current.MainPage.DisplayAlert("Atencion", "Rellena todos los campos", "OK");
        }
        #endregion
    }
}
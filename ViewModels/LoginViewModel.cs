using Firebase.Auth.Providers;
using Firebase.Auth;

namespace AppComida.ViewModels
{
    public class LoginViewModel
    {
        FirebaseAuthClient client;
        public Command AnonymousSignIn { get; }
        public LoginViewModel() 
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyBbZwbPPphYoPmzUjS-69jxahwM4jrcbww",
                AuthDomain = "comidaapp-677d2.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            client = new FirebaseAuthClient(config);
            AnonymousSignIn = new Command(SignInAsAnonymous);
        }

        public async void SignInAsAnonymous(object obj) 
        {
            var user = await client.SignInAnonymouslyAsync();
            if (user == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Firebase Anonymous Authentication", "Ok");
                return;
            }
            await App.Current.MainPage.Navigation.PushAsync(new Menu(new MenuViewModel()));
        }

        //public async void SignInWithEmailProvider(object obj)
        //{
            
        //}
    }
}

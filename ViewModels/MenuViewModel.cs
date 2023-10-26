using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppComida.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        // AMEL a DAMARIS: Esta variable almacena el nombre de la imagen que mostrará en el menu.
        public string BackgroundImage { get; set; }

<<<<<<< HEAD
        // AMEL a DAMARIS: Esta propiedad nos permite utilizar la navegacion de la ventana donde estamos actualmente
        readonly INavigation _navigation;

        // AMEL a DAMARIS: Este constructor se inicia cuando se inicia la ventana
        public MenuViewModel(INavigation navigation)
=======
        // AMEL a DAMARIS: Este constructor se inicia cuando se inicia la ventana
        public MenuViewModel()
>>>>>>> b43548807bbbd135cb02d98b14646178e1673c4f
        {
            // AMEL: Primero comprueba si el dispositivo es Android o iOS
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Si lo es... cargara "fondo.jpg"
                BackgroundImage = "fondo.jpg";
            }
            else
            {
                // Si no lo es... cargará "windows.png"
                BackgroundImage = "windows.png";
            }

<<<<<<< HEAD
            // Iniciamos las propiedades abstractas
            this._navigation = navigation;

=======
>>>>>>> b43548807bbbd135cb02d98b14646178e1673c4f
            // Convertimos nuestros metodos en commandos para utilizar en el view
            this.AbrirContacto = new Command(Abrircontacto);
        }

        // AMEL a DAMARIS: Este objeto actualza las propiedades que cambiemos aquí
        public event PropertyChangedEventHandler PropertyChanged;
        // AMEL a DAMARIS: Este metodo lo llamaremos en cada set de cada propiedad para que actualice los datos en el view
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // AMEL a DAMARIS: Si propertyName cambia se invocará PropertyChanged
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // AMEL a DAMARIS: Este es mi comando para abrir mi ventana de contacto
        public Command AbrirContacto { get; }

        // AMELa DAMARIS: Este metodo es lo que ejecutará mi comando AbrirContacto
        public async void Abrircontacto(object obj)
        {
<<<<<<< HEAD
            await _navigation.PushAsync(new Contacto(new ContactoViewModel(Email.Default)));
=======
            await App.Current.MainPage.Navigation.PushAsync(new Contacto(new ContactoViewModel()));
>>>>>>> b43548807bbbd135cb02d98b14646178e1673c4f
        }
    }
}
